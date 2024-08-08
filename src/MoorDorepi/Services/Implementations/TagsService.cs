using MoorDorepi.Models;
using MoorDorepi.Services.Abstractions;
using Newtonsoft.Json;

namespace MoorDorepi.Services.Implementations;

internal sealed class TagsService(HttpClient client) : ITagsService
{
    public async Task<ImageTags?> GetAsync(string repositoryName, CancellationToken cancellationToken = default)
    {
        var response = await client.GetAsync($"v2/{repositoryName}/tags/list", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<ImageTags>(content);
    }
}