using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Planning.Handlebars;

#pragma warning disable SKEXP0060

namespace Demo;

internal class Demo06_HandlebarsPlanner : TestBase
{
    public Demo06_HandlebarsPlanner(IConfiguration configuration)
    : base(configuration)
    {
    }

    internal override async Task Go()
    {
        Console.Clear();
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("** Handlebars Planner                                                         **");
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();

        var kernel = BuildKernel();

        // Add plugins.
        kernel.ImportPluginFromType<Plugins.WeatherPlugin>();
        kernel.ImportPluginFromType<Plugins.MathPlugin>();

        // TODO: Set prompt.
        var prompt = "Lookup the weather for York and add the numbers 34 and 56 together.";

        HandlebarsPlanner planner = new(new HandlebarsPlannerOptions() { AllowLoops = true });
        var plan = await planner.CreatePlanAsync(kernel, prompt);

        Console.WriteLine($"Plan: {plan}");

        var result = await plan.InvokeAsync(kernel);

        Console.WriteLine(result);

        Console.WriteLine();
        Console.WriteLine("Complete. Press enter to continue.");
        Console.ReadLine();
    }
}

#pragma warning restore SKEXP0060
