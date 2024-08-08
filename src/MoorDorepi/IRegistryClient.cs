using MoorDorepi.Services.Abstractions;

namespace MoorDorepi;

public interface IRegistryClient : IDisposable
{
    ICatalogService Catalog { get; }
    ITagsService Tags { get; }
    IManifestService Manifest { get; }
    ISystemService System { get; }
}