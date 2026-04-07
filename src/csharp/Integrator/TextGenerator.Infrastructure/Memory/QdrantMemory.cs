using Google.Protobuf.Collections;
using Qdrant.Client;
using Qdrant.Client.Grpc;
using TextGenerator.Core.Interfaces.Memorize;

namespace TextGenerator.Infrastructure.Memory;

    public class QdrantMemory : IMemory
    {
        private readonly QdrantClient _client;
        private const string CollectionName = "game_memories";

        public QdrantMemory(string host = "localhost", int port = 6333)
        {
            _client = new QdrantClient(host, port);
            EnsureCollectionExists().GetAwaiter().GetResult();
        }

        private async Task EnsureCollectionExists()
        {
            var collections = await _client.ListCollectionsAsync();
            if (!collections.Contains(CollectionName))
            {
                await _client.CreateCollectionAsync(CollectionName,
                    new VectorParams { Size = 384, Distance = Distance.Cosine });
            }
        }

        public async Task AddMemory(string text, float[] embedding, string metadata)
        {
            // Convert float[] to ReadOnlyMemory<float>
            var vectorMemory = new ReadOnlyMemory<float>(embedding);

            // Build payload as MapField<string, Value>
            var payload = new MapField<string, Value>
            {
                { "text", new Value { StringValue = text } },
                { "metadata", new Value { StringValue = metadata } }
            };

            var point = new PointStruct
            {
                Id = Guid.NewGuid(),
                Vectors = new Vectors
                {
                    Vector = embedding
                }
            };
            
            point.Payload.Add("text", new Value { StringValue = text });
            point.Payload.Add("metadata", new Value { StringValue = metadata });

            await _client.UpsertAsync(CollectionName, new[] { point });
        }

        public async Task<List<(string Text, float Score)>> RetrieveRelevant(string query, float[] queryEmbedding, int topK = 5)
        {
            var vectorMemory = new ReadOnlyMemory<float>(queryEmbedding);
            var searchResult = await _client.SearchAsync(CollectionName, vectorMemory, limit: (ulong)topK);

            var result = new List<(string Text, float Score)>();
            foreach (var scoredPoint in searchResult)
            {
                if (scoredPoint.Payload.TryGetValue("text", out var textValue))
                {
                    var text = textValue.StringValue ?? string.Empty;
                    result.Add((text, scoredPoint.Score));
                }
            }
            return result;
        }
    }