using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

namespace Demo;

internal class Demo03_NativeFunctions : TestBase
{
    public Demo03_NativeFunctions(IConfiguration configuration)
    : base(configuration)
    {
    }

    internal override async Task Go()
    {
        Console.Clear();
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("** Native Functions                                                           **");
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();

        var kernel = BuildKernel();

        var functions = kernel.ImportPluginFromType<Plugins.WeatherPlugin>();
        var result = await kernel.InvokeAsync(functions["Lookup"], new()
        {
            { "location", "York" }
        });
        Console.WriteLine(result);

        functions = kernel.ImportPluginFromType<Plugins.MathPlugin>();
        result = await kernel.InvokeAsync(functions["Add"], new()
        {
            { "number1", "43" },
            { "number2", "31" },
        });
        Console.WriteLine(result);

        Console.WriteLine();
        Console.WriteLine("Complete. Press enter to continue.");
        Console.ReadLine();
    }
}
