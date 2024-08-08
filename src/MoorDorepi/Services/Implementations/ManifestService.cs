using MoorDorepi.Constants;
using MoorDorepi.Services.Abstractions;

namespace MoorDorepi.Services.Implementations;

internal sealed class ManifestService(HttpMessageInvoker client) : IManifestService
{
    public async Task<string> GetRawAsync(string name, string reference, CancellationToken cancellationToken)
    {
        var response = await client.SendAsync(MakeGetRequest(name, reference), cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }

    private static HttpRequestMessage MakeGetRequest(string name, string reference)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"v2/{name}/manifests/{reference}");
        request.Headers.Add("Accept", $"{ManifestMediaTypes.ManifestSchema1}, " +
                                      $"{ManifestMediaTypes.ManifestSchema2}, {ManifestMediaTypes.ManifestList}, " +
                                      $"{ManifestMediaTypes.ManifestSchema1Signed}");

        return request;
    }
}