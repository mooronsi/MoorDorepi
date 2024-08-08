namespace MoorDorepi.QueryParameters;

public sealed class CatalogQueryParameters
{
    [QueryParameter("n")]
    public int? Number { get; init; }

    [QueryParameter("last")]
    public string? Last { get; init; }
}