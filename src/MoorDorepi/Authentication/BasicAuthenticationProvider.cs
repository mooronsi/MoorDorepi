using System.Net.Http.Headers;
using System.Text;

namespace MoorDorepi.Authentication;

public sealed class BasicAuthenticationProvider(string username, string password) : AuthenticationProvider
{
    public override void Apply(ref HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))
        );
    }
}