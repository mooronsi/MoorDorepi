using System.Reflection;
using MoorDorepi.QueryParameters;

namespace MoorDorepi.Utils;

internal static class QueryParameterUtils
{
    public static string? ToQueryString<T>(T parameters)
    {
        if (parameters == null) return null;

        var parametersDictionary = new Dictionary<string, string>();

        var properties = typeof(T).GetProperties();
        foreach (var propertyInfo in properties)
        {
            var attribute = propertyInfo.GetCustomAttribute<QueryParameterAttribute>();
            if (attribute is null) continue;

            var value = propertyInfo.GetValue(parameters);
            if (value is null) continue;

            parametersDictionary.Add(attribute.Key, value.ToString() ?? string.Empty);
        }

        return string.Join("&", parametersDictionary
            .Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value))
            .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));
    }
}