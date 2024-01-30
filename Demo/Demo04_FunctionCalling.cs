using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace Demo;

internal class Demo04_FunctionCalling : TestBase
{
    public Demo04_FunctionCalling(IConfiguration configuration)
    : base(configuration)
    {
    }

    internal override async Task Go()
    {
        Console.Clear();
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("** Function Calling                                                           **");
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("** Manual Execution ************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();
        await ManualExecution();

        Console.WriteLine();
        Console.WriteLine("** Automatic Execution *********************************************************");        
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();
        await AutomaticExecution();

        Console.WriteLine();
        Console.WriteLine("Complete. Press enter to continue.");
        Console.ReadLine();
    }

    private async Task ManualExecution()
    {
        var kernel = BuildKernel();

        kernel.ImportPluginFromType<Plugins.WeatherPlugin>();
        kernel.ImportPluginFromType<Plugins.MathPlugin>();

        var prompt = @"Lookup the weather for York and add the numbers 34 and 56 together.";

        OpenAIPromptExecutionSettings settings = new()
        {
            ToolCallBehavior = ToolCallBehavior.EnableKernelFunctions,
			Temperature = 0
        };

        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        var chatHistory = new ChatHistory();
        chatHistory.AddUserMessage(prompt);        

        while (true)
        {
            var result = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, kernel);

            if (result.Content is not null) Console.WriteLine(result.Content);

            var functionCalls = ((OpenAIChatMessageContent)result).GetOpenAIFunctionToolCalls().ToList();
            if (functionCalls.Count == 0) break;

            chatHistory.Add(result);            
            foreach (var functionCall in functionCalls)
            {
                string content = kernel.Plugins.TryGetFunctionAndArguments(functionCall, out KernelFunction? function, out KernelArguments? arguments) ?
                    JsonSerializer.Serialize((await function.InvokeAsync(kernel, arguments)).GetValue<object>()) :
                    "Unable to find function, please try again.";
                
                chatHistory.Add(new ChatMessageContent(
                    AuthorRole.Tool, content, metadata: new Dictionary<string, object?>(1) { { OpenAIChatMessageContent.ToolIdProperty, functionCall.Id } }));
            }
        }
    }

    private async Task AutomaticExecution()
    {
        var kernel = BuildKernel();

        kernel.ImportPluginFromType<Plugins.WeatherPlugin>();
        kernel.ImportPluginFromType<Plugins.MathPlugin>();

        var prompt = @"Lookup the weather for York and add the numbers 34 and 56 together.";
        
        OpenAIPromptExecutionSettings settings = new()
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
			Temperature = 0
        };

        var result = await kernel.InvokePromptAsync(prompt, new KernelArguments(settings));

        Console.WriteLine(result);
    }
}
