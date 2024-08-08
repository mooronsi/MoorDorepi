namespace MoorDorepi.QueryParameters;

[AttributeUsage(AttributeTargets.Property)]
public sealed class QueryParameterAttribute(string key) : Attribute
{
    public string Key { get; } = key;
}