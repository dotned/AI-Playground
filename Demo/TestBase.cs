using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Shared.Extensions;

namespace Demo;

internal abstract class TestBase
{
    private readonly IConfiguration _configuration;
    private readonly string _azureOpenAIChatCompletionDeploymentName;
    private readonly string _azureOpenAIChatCompletionModelId;
    private readonly string _azureOpenAIEndpoint;
    private readonly string _azureOpenAIApiKey;

    public TestBase(IConfiguration configuration)
    {
        _configuration = configuration;
        _azureOpenAIChatCompletionDeploymentName = configuration.GetString("AzureOpenAI:ChatCompletionDeploymentName");
        _azureOpenAIChatCompletionModelId = configuration.GetString("AzureOpenAI:ChatCompletionModelId");
        _azureOpenAIEndpoint = configuration.GetString("AzureOpenAI:Endpoint");
        _azureOpenAIApiKey = configuration.GetString("AzureOpenAI:ApiKey");
    }

    internal abstract Task Go();

    internal Kernel BuildKernel(bool withLogging = false)
    {
        var builder = Kernel.CreateBuilder();
        if (withLogging) builder.Services.AddLogging(c => c.AddDebug().SetMinimumLevel(LogLevel.Trace));
        builder.Services.AddAzureOpenAIChatCompletion(
            _azureOpenAIChatCompletionDeploymentName,
            _azureOpenAIEndpoint,
            _azureOpenAIApiKey,
            modelId: _azureOpenAIChatCompletionModelId);
        return builder.Build();
    }
}
