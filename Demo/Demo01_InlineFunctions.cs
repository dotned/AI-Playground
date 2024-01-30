using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

namespace Demo;

internal class Demo01_InlineFunctions : TestBase
{
    public Demo01_InlineFunctions(IConfiguration configuration)
    : base(configuration)
    {
    }

    internal override async Task Go()
    {
        Console.Clear();
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("** Inline Functions                                                           **");
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();

        var kernel = BuildKernel();

        var prompt = @"
            {{$input}}

            Rewrite the above in the style of Shakespeare
            ";

        var settings = new PromptExecutionSettings
        {
            ExtensionData = new Dictionary<string, object>
            {
                { "temperature", 0.9 }
            }
        };

        var function = kernel.CreateFunctionFromPrompt(prompt, settings);

        

        var result = await kernel.InvokeAsync(function, new() {
            { "input", "I'm so fascinated by all of the AI technologies." }
        });
        Console.WriteLine(result);

        Console.WriteLine();
        Console.WriteLine("Complete. Press enter to continue.");
        Console.ReadLine();
    }
}
