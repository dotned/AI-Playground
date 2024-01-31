using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

namespace Demo;

internal class Demo02_SemanticFunctions : TestBase
{
    public Demo02_SemanticFunctions(IConfiguration configuration)
    : base(configuration)
    {
    }

    internal override async Task Go()
    {
        Console.Clear();
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("** Semantic Functions                                                         **");
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();

        var kernel = BuildKernel();

        var functionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Demo", "Plugins", "FunPlugin");
        var functions = kernel.ImportPluginFromPromptDirectory(functionDirectory);

        var excuse = await kernel.InvokeAsync(functions["Excuses"], new() {
            { "input", "my cat" }
        });
        Console.WriteLine(excuse);

        var joke = await kernel.InvokeAsync(functions["Joke"], new() {
            { "input", "swimming" }
        });
        Console.WriteLine(joke);

        var limerick = await kernel.InvokeAsync(functions["Limerick"], new() {
            { "name", "Mike" },
            { "input", "Airplanes" }
        });
        Console.WriteLine(limerick);

        Console.WriteLine();
        Console.WriteLine("Complete. Press enter to continue.");
        Console.ReadLine();
    }
}
