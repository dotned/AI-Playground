using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

namespace Demo;

internal class Demo00_Prompts : TestBase
{
    public Demo00_Prompts(IConfiguration configuration)
    : base(configuration)
    {
    }

    internal override async Task Go()
    {
        Console.Clear();
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("** Prompts                                                                    **");
        Console.WriteLine("********************************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("** Q n A ***********************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();
        await QnA();

        Console.WriteLine();
        Console.WriteLine("** Conversation ****************************************************************");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();
        await Conversation();

        Console.WriteLine();
        Console.WriteLine("Complete. Press enter to continue.");
        Console.ReadLine();
    }

    private async Task QnA()
    {
        var kernel = BuildKernel();

        while(true)
        {
            Console.Write("Q: ");
            var prompt = Console.ReadLine() ?? string.Empty;
            if (prompt == "quit") break;

            var result = await kernel.InvokePromptAsync(prompt);

            Console.WriteLine($"A: {result}");
            Console.WriteLine();
        }
    }

     private async Task Conversation()
    {
        var kernel = BuildKernel();
        var history = string.Empty;

        while(true)
        {
            Console.Write("Q: ");
            var prompt = Console.ReadLine() ?? string.Empty;
            if (prompt == "quit") break;

            var promptWithHistory = history + $"Input: {prompt}";

            var result = await kernel.InvokePromptAsync(promptWithHistory);

            Console.WriteLine($"A: {result}");
            Console.WriteLine();

            history += $"<message role=\"user\">{prompt}\n";
            history += $"<message role=\"assistant\">{result}\n";
        }
    }
}
