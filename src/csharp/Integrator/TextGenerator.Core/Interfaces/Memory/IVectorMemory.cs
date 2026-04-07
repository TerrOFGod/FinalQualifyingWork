namespace TextGenerator.Core.Interfaces.Memory;

public interface IVectorMemory
{
    float[] GetEmbedding(string text);
}