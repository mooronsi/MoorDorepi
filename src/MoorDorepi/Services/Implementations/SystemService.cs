using MoorDorepi.Services.Abstractions;

namespace MoorDorepi.Services.Implementations;

internal sealed class SystemService(HttpClient client) : ISystemService
{
    public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken = default)
    {
        var response = await client.GetAsync("v2/", cancellationToken);
        return response.IsSuccessStatusCode;
    }

    public async Task<(bool IsAvailable, string ErrorMessage)> IsAvailableWithMessageAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await client.GetAsync("v2/", cancellationToken);
        if (response.IsSuccessStatusCode) return (true, string.Empty);

        var errorMessage = await response.Content.ReadAsStringAsync(cancellationToken);
        return (false, errorMessage);
    }
}