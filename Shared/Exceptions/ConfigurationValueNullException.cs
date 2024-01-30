namespace Shared.Exceptions;

public class ConfigurationValueNullException : Exception
{
    public ConfigurationValueNullException()
    {
    }

    public ConfigurationValueNullException(string key)
        : base($"Value not found for key '{key}'")
    {
    }
}
