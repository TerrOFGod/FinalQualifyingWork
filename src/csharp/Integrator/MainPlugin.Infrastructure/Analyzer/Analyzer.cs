//using BERTTokenizers;
using FastBertTokenizer;
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
        private static BertTokenizer tokenizer;
        private InferenceSession _onnxSession;

        public Analyzer()
        {
            tokenizer = new BertTokenizer();
            tokenizer.LoadTokenizerJsonAsync("bert-base-uncased").Wait();
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
                // Encode the sentence and get the InputIds, AttentionMask and TypeIds.
                var (inputIds, attentionMask, typeIds) = tokenizer.Encode(branch);

                // Run the model.
                var score = ValidateDialogue(inputIds.ToArray(), attentionMask.ToArray());

                if (score < 0.5)
                    return false;
            }

            return true;
        }
    }
}

