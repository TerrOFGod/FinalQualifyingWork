namespace TextGenerator.Infrastructure.EdgeAI;

public class LLamaSharpOptions
{
    public string ModelPath { get; set; } = "models/Meta-Llama-3-8B.Q4_K_M.gguf";
    
    /// <summary>Количество слоёв, выгружаемых на GPU. 0 = только CPU.</summary>
    public int GpuLayerCount { get; set; } = 20;
    
    /// <summary>Размер контекста (токенов).</summary>
    public uint ContextSize { get; set; } = 2048;
    
    /// <summary>Размер батча для инференса.</summary>
    public uint BatchSize { get; set; } = 512;
}