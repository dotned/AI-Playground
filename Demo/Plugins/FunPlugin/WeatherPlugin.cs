using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Demo.Plugins;

public class WeatherPlugin
{
    public const string PluginName = "weather";

    [KernelFunction, Description("Looks up the current weather details for a given location")]
    public async Task<string> LookupAsync(
        [Description("The location to look up weather conditions for")] string location)
    {
        await Task.Delay(100);
        return await Task.FromResult("Sunny");
    }
}
