using MoorDorepi.Models;
using MoorDorepi.QueryParameters;
using MoorDorepi.Services.Abstractions;
using MoorDorepi.Utils;
using Newtonsoft.Json;

namespace MoorDorepi.Services.Implementations;

internal sealed class CatalogService(HttpClient client) : ICatalogService
{
    public async Task<Catalog?> GetAsync(CatalogQueryParameters? parameters = null,
        CancellationToken cancellationToken = default)
    {
        parameters ??= new CatalogQueryParameters();
        var queryParameters = QueryParameterUtils.ToQueryString(parameters);

        var requestUri = $"v2/_catalog{(string.IsNullOrWhiteSpace(queryParameters)
            ? string.Empty
            : $"?{queryParameters}")}";

        var response = await client.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<Catalog>(content);
    }
}