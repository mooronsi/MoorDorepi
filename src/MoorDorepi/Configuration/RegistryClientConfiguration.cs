namespace MoorDorepi.Configuration;

public sealed class RegistryClientConfiguration(string baseAddress)
{
    public string BaseAddress { get; init; } = baseAddress;
}