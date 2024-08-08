namespace MoorDorepi.Services.Abstractions;

public interface IManifestService
{
    Task<string> GetRawAsync(string name, string reference, CancellationToken cancellationToken = default);
}