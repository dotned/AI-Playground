using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Demo;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile("appsettings.Development.json", true, true)
            .AddJsonFile($"appsettings.{Environment.UserName}.json", true, true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables();
        var configuration = builder.Build();

        TestBase test;

        test = new Demo00_Prompts(configuration);
        await test.Go();

        //test = new Demo01_InlineFunctions(configuration);
        //await test.Go();

        //test = new Demo02_SemanticFunctions(configuration);
        //await test.Go();

        //test = new Demo03_NativeFunctions(configuration);
        //await test.Go();

        test = new Demo04_FunctionCalling(configuration);
        await test.Go();

        //test = new Demo05_FunctionCallingStepwisePlanner(configuration);
        //await test.Go();

        //test = new Demo06_HandlebarsPlanner(configuration);
        //await test.Go();

        Console.Clear();
        Console.WriteLine("Demo complete. Press enter to exit.");
        Console.ReadLine();
    }
}
