using Newtonsoft.Json;

namespace MoorDorepi.Models;

public sealed class ImageTags
{
    [JsonProperty("name")]
    public string Name { get; internal set; } = string.Empty;

    [JsonProperty("tags")]
    public string[] Tags { get; internal set; } = [];

    public override string ToString() =>
        $"ImageTags {{ Name = {Name}, Tags = [{string.Join(", ", Tags)}] }}";
}