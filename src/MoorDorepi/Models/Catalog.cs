using Newtonsoft.Json;

namespace MoorDorepi.Models;

public sealed record Catalog
{
    [JsonProperty("repositories")]
    public string[] Repositories { get; internal set; } = [];

    public override string ToString() =>
        $"Catalog {{ Repositories = [{string.Join(", ", Repositories)}] }}";
}