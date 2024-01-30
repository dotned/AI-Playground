using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Demo.Plugins;

public class MathPlugin
{
    public const string PluginName = "math";

    [KernelFunction, Description("Take the square root of a number")]
    public async Task<double> Sqrt(
        [Description("The number to take a square root of")] double number1)
    {
        var result = System.Math.Sqrt(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Add two numbers")]
    public async Task<double> Add(
        [Description("The first number to add")] double number1,
        [Description("The second number to add")] double number2)
    {
        var result = number1 + number2;
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Subtract two numbers")]
    public async Task<double> Subtract(
        [Description("The first number to subtract from")] double number1,
        [Description("The second number to subtract away")] double number2)
    {
        var result = number1 - number2;
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Multiply two numbers. When increasing by a percentage, don't forget to add 1 to the percentage.")]
    public async Task<double> Multiply(
        [Description("The first number to multiply")] double number1,
        [Description("The second number to multiply")] double number2)
    {
        var result = number1 * number2;
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Divide two numbers")]
    public async Task<double> Divide(
        [Description("The first number to divide from")] double number1,
        [Description("The second number to divide by")] double number2)
    {
        var result = number1 / number2;
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Raise a number to a power")]
    public async Task<double> Power(
    [Description("The number to raise")] double number1,
    [Description("The power to raise the number to")] double number2
)
    {
        var result = System.Math.Pow(number1, number2);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the log of a number")]
    public async Task<double> Log(
        [Description("The number to take the log of")] double number1,
        [Description("The base of the log")] double number2
    )
    {
        var result = System.Math.Log(number1, number2);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Round a number to the target number of decimal places")]
    public async Task<double> Round(
        [Description("The number to round")] double number1,
        [Description("The number of decimal places to round to")] double number2
    )
    {
        var result = System.Math.Round(number1, (int)number2);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the absolute value of a number")]
    public async Task<double> Abs(
        [Description("The number to take the absolute value of")] double number1
    )
    {
        var result = System.Math.Abs(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the floor of a number")]
    public async Task<double> Floor(
        [Description("The number to take the floor of")] double number1
    )
    {
        var result = System.Math.Floor(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the ceiling of a number")]
    public async Task<double> Ceiling(
        [Description("The number to take the ceiling of")] double number1
    )
    {
        var result = System.Math.Ceiling(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the sine of a number")]
    public async Task<double> Sin(
        [Description("The number to take the sine of")] double number1
    )
    {
        var result = System.Math.Sin(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the cosine of a number")]
    public async Task<double> Cos(
        [Description("The number to take the cosine of")] double number1
    )
    {
        var result = System.Math.Cos(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the tangent of a number")]
    public async Task<double> Tan(
        [Description("The number to take the tangent of")] double number1
    )
    {
        var result = System.Math.Tan(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the arcsine of a number")]
    public async Task<double> Asin(
        [Description("The number to take the arcsine of")] double number1
    )
    {
        var result = System.Math.Asin(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the arccosine of a number")]
    public async Task<double> Acos(
        [Description("The number to take the arccosine of")] double number1
    )
    {
        var result = System.Math.Acos(number1);
        return await Task.FromResult(result);
    }

    [KernelFunction, Description("Take the arctangent of a number")]
    public async Task<double> Atan(
        [Description("The number to take the arctangent of")] double number1
    )
    {
        var result = System.Math.Atan(number1);
        return await Task.FromResult(result);
    }
}
