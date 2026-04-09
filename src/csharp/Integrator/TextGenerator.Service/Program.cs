using Microsoft.VisualStudio.Threading;
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
//using TextGenerator.Infrastructure.Reward;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<JoinableTaskContext>();

// 1. Конфигурация локальной LLM
builder.Services.Configure<LLamaSharpOptions>(builder.Configuration.GetSection("LLama"));
builder.Services.AddSingleton<ILLMClient, LocalLLMClient>();

// 2. Компоненты памяти и RAG
builder.Services.AddSingleton<IEmbeddingGenerator, EmbeddingGeneratorService>();
builder.Services.AddSingleton<IVectorMemoryStore, QdrantVectorMemoryStore>(); // требуется Qdrant.Client
builder.Services.AddScoped<IRAGService, RAGService>();
builder.Services.AddScoped<ITextSummarizer, TextSummarizer>();
builder.Services.AddScoped<IDialogueCache, DialogueCache>();
builder.Services.AddMemoryCache(); // IMemoryCache

// 3. Narrative Environment
builder.Services.AddSingleton<INarrativeEnvironment, NarrativeEnvironmentService>();

// 4. LLM prompt builder and response parser
builder.Services.AddScoped<ILLMPromptBuilder, LLMPromptBuilder>();
builder.Services.AddScoped<ILLMResponseParser, LLMResponseParser>();

// 5. Обновлённые пре/постпроцессоры
builder.Services.AddScoped<IPreprocessor, PreprocessorService>();
builder.Services.AddScoped<IPostprocessor, PostprocessorService>();

// 6. Система наград и метрик
//builder.Services.AddSingleton<IDialogueValidator, DialogueValidator>(); // если модель ONNX доступна
//builder.Services.AddSingleton<IRewardCalculator, RewardCalculator>();
//builder.Services.AddSingleton<IFeedbackCollector, FeedbackCollector>();
//builder.Services.AddSingleton<IModelFineTuner, ModelFineTuner>();

// 7. Нарративный контекст
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