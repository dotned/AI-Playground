using System.Reflection;

namespace Shared.Helpers;

internal static class EmbeddedResource
{
    internal static string Read(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var assemblyName = assembly.GetName().Name;
        resourceName = $"{assemblyName}.Resources.{resourceName}";

        using Stream? stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) throw new Exceptions.ResourceNotFoundExeption(resourceName);
        using StreamReader reader = new(stream);
        string resource = reader.ReadToEnd();

        return resource;
    }
}
