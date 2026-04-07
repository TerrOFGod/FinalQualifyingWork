using TextGenerator.Core.Interfaces.Cache;
using TextGenerator.Core.Interfaces.EdgeAI;
using TextGenerator.Core.Interfaces.Memory;
using TextGenerator.Core.Interfaces.Narrative;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Core.Interfaces.RAG;
using TextGenerator.Infrastructure.Caching;
using TextGenerator.Infrastructure.EdgeAI;
using TextGenerator.Infrastructure.Memory;
using TextGenerator.Infrastructure.Narrative.Agents;
using TextGenerator.Infrastructure.Narrative.Environment;
using TextGenerator.Infrastructure.Processors;
using TextGenerator.Infrastructure.RAG;
using TextGenerator.Infrastructure.Reward;

var builder = WebApplication.CreateBuilder(args);


// 1. Конфигурация локальной LLM
builder.Services.Configure<LLamaSharpOptions>(builder.Configuration.GetSection("LocalLLM"));
builder.Services.AddSingleton<ILLMClient, LocalLLMClient>();

// 2. Компоненты памяти и RAG
builder.Services.AddSingleton<IVectorMemory, VectorMemoryService>();
builder.Services.AddSingleton<IMemory, QdrantMemory>(); // требуется Qdrant.Client
builder.Services.AddScoped<IRAGService, RAGService>();
builder.Services.AddScoped<ISummarizer, Summarizer>();
builder.Services.AddScoped<IDialogueCache, DialogueCache>();
builder.Services.AddMemoryCache(); // IMemoryCache

// 3. Narrative Environment
builder.Services.AddSingleton<INarrativeEnvironment, NarrativeEnvironmentService>();

// 4. Пре/постпроцессоры
builder.Services.AddScoped<IPreprocessor, PreprocessorService>();
builder.Services.AddScoped<IPostprocessor, PostprocessorService>();

// 5. Система наград и метрик
builder.Services.AddSingleton<IAnalyzer, DialogueAnalyzer>(); // если модель ONNX доступна
builder.Services.AddSingleton<IRewardCalculator, RewardCalculator>();
builder.Services.AddSingleton<IRewardCollector, RewardCollector>();

// 6. Нарративный агент
builder.Services.AddScoped<INarrativeAgent, NarrativeAgent>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();