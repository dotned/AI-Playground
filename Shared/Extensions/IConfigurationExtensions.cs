using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace Shared.Extensions;

public static class IConfigurationExtensions
{
    public static T Get<T>(this IConfiguration configuration, string path)
    {
        var value = configuration.GetValue<T>(path);
        if (value == null) throw new Exceptions.ConfigurationValueNullException(path);
        return value;
    }

    public static T Get<T>(this IConfiguration configuration, string path, T defaultValue)
    {
        var value = configuration.GetValue<T>(path);
        if (value == null) return defaultValue;
        return value;
    }

    public static string GetString(this IConfiguration configuration, string path)
    {
        return Get<string>(configuration, path);
    }

    public static string GetString(this IConfiguration configuration, string path, string defaultValue)
    {
        return Get(configuration, path, defaultValue);
    }
}
