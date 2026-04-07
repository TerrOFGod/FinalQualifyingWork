using TextGenerator.Core.Interfaces.Memorize;
using TextGenerator.Core.Interfaces.Processors;
using TextGenerator.Infrastructure.Agents;
using TextGenerator.Infrastructure.API;
using TextGenerator.Infrastructure.Processors;
using TextGenerator.Infrastructure.Analyzer;
using TextGenerator.Infrastructure.EdgeAI;
using TextGenerator.Infrastructure.Memory;
using TextGenerator.Infrastructure.RAG;
using TextGenerator.Infrastructure.Reward;

var builder = WebApplication.CreateBuilder(args);

// Настройка OpenAI
var openAIConfig = builder.Configuration.GetSection("OpenAI");
var apiKey = openAIConfig["ApiKey"] ?? throw new InvalidOperationException("OpenAI ApiKey missing");
var baseUrl = openAIConfig["BaseUrl"] ?? "https://api.openai.com/v1/";
var model = openAIConfig["Model"] ?? "gpt-3.5-turbo";

builder.Services.AddSingleton(new GptApiClient(apiKey, baseUrl, model));

// 1. Конфигурация локальной LLM
builder.Services.Configure<LLamaSharpOptions>(builder.Configuration.GetSection("LocalLLM"));
builder.Services.AddSingleton<LocalLLMClient>();

// 2. Компоненты памяти и RAG
builder.Services.AddSingleton<VectorMemoryService>();
builder.Services.AddSingleton<IMemory, QdrantMemory>(); // требуется Qdrant.Client
builder.Services.AddScoped<RAGService>();
builder.Services.AddScoped<Summarizer>();

// 3. Пре/постпроцессоры
builder.Services.AddScoped<IPreprocessor, Preprocessor>();
builder.Services.AddScoped<IPostprocessor, Postprocessor>();

// 4. Система наград
builder.Services.AddSingleton<IAnalyzer, Analyzer>(); // если модель ONNX доступна
builder.Services.AddSingleton<IRewardSystem, RewardCalculator>();

// 5. Нарративный агент
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