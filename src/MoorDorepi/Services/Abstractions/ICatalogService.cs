using MoorDorepi.Models;
using MoorDorepi.QueryParameters;

namespace MoorDorepi.Services.Abstractions;

public interface ICatalogService
{
    Task<Catalog?> GetAsync(
        CatalogQueryParameters? parameters = null,
        CancellationToken cancellationToken = default);
}