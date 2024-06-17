using BERTTokenizers;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using GPTTextGenerator.Entities.Interfaces.Processors;

namespace GPTTextGenerator.Infrastructure.Analyzer
{
    public struct BertInput
    {
        public long[] InputIds { get; set; }
        public long[] AttentionMask { get; set; }
        public long[] TypeIds { get; set; }
    }

    public class Analyzer : IAnalyzer
    {
        private static BertUncasedBaseTokenizer tokenizer;
        private InferenceSession _onnxSession;

        public Analyzer()
        {
            tokenizer = new BertUncasedBaseTokenizer();
            _onnxSession = new InferenceSession("dialogue_classifier.onnx");
        }

        public float ValidateDialogue(long[] inputIds, long[] attentionMask)
        {
            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input_ids",
                    new DenseTensor<long>(inputIds, new[] { 1, inputIds.Length })),
                NamedOnnxValue.CreateFromTensor("attention_mask",
                    new DenseTensor<long>(attentionMask, new[] { 1, attentionMask.Length }))
            };

            using var results = _onnxSession.Run(inputs);
            var output = results.First().AsTensor<float>().ToArray();

            return output[0];  // Возвращаем вероятность корректности диалога
        }

        public bool CheckCorrections(List<string> dialogueBranches)
        {
            foreach (var branch in dialogueBranches)
            {
                // Get the sentence tokens.
                var tokens = tokenizer.Tokenize(branch);
                // Console.WriteLine(String.Join(", ", tokens));

                // Encode the sentence and pass in the count of the tokens in the sentence.
                var encoded = tokenizer.Encode(tokens.Count, branch);

                // Break out encoding to InputIds, AttentionMask and TypeIds from list of (input_id, attention_mask, type_id).
                var bertInput = new BertInput()
                {
                    InputIds = encoded.Select(t => t.InputIds).ToArray(),
                    AttentionMask = encoded.Select(t => t.AttentionMask).ToArray(),
                    TypeIds = encoded.Select(t => t.TokenTypeIds).ToArray(),
                };

                // Run the model.
                var score = ValidateDialogue(bertInput.InputIds, bertInput.AttentionMask);

                if (score < 0.5)
                    return false;
            }

            return true;
        }
    }
}
