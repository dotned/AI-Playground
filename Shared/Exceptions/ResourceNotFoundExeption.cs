namespace Shared.Exceptions;

public class ResourceNotFoundExeption : Exception
{
    public ResourceNotFoundExeption()
    {
    }

    public ResourceNotFoundExeption(string resourceName)
        : base($"Resource '{resourceName}' not found")
    {
    }
}
