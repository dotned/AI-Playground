using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Planning;

#pragma warning disable SKEXP0061

namespace Demo;

internal class Demo05_FunctionCallingStepwisePlanner : TestBase
{
    public Demo05_FunctionCallingStepwisePlanner(IConfiguration configuration)
    : base(configuration)
    {
    }

    internal override async Task Go()
    {
        Console.Clear();
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("** Function Calling Stepwise Planner                                          **");
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();

        var kernel = BuildKernel();

        // Add plugins.
        kernel.ImportPluginFromType<Plugins.WeatherPlugin>();
        kernel.ImportPluginFromType<Plugins.MathPlugin>();

        // TODO: Set prompt.
        var prompt = "Lookup the weather for York and add the numbers 34 and 56 together.";

        FunctionCallingStepwisePlanner planner = new();
        var result = await planner.ExecuteAsync(kernel, prompt);

        Console.WriteLine(result.FinalAnswer);
        foreach(var chat in result.ChatHistory)
        {
            Console.WriteLine($"{chat.Content}");
        }

        Console.WriteLine();
        Console.WriteLine("Complete. Press enter to continue.");
        Console.ReadLine();
    }
}

#pragma warning restore SKEXP0061
