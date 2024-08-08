using MoorDorepi.Authentication;
using MoorDorepi.Configuration;
using MoorDorepi.Services.Abstractions;
using MoorDorepi.Services.Implementations;

namespace MoorDorepi;

public sealed class RegistryClient : IRegistryClient
{
    private readonly HttpClient _client;

    public RegistryClient(
        RegistryClientConfiguration configuration,
        AuthenticationProvider? authenticationProvider = null)
    {
        _client = new HttpClient();

        if (!Uri.TryCreate(configuration.BaseAddress, UriKind.Absolute, out var uri))
            throw new ArgumentException("Invalid base address.", nameof(configuration.BaseAddress));

        _client.BaseAddress = uri;
        authenticationProvider?.Apply(ref _client);

        Catalog = new CatalogService(_client);
        Tags = new TagsService(_client);
        Manifest = new ManifestService(_client);
        System = new SystemService(_client);
    }

    public ICatalogService Catalog { get; }
    public ITagsService Tags { get; }
    public IManifestService Manifest { get; }
    public ISystemService System { get; }

    #region Dispose

    private bool _isDisposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            _client.Dispose();
        }

        _isDisposed = true;
    }

    ~RegistryClient()
    {
        Dispose(false);
    }

    #endregion
}