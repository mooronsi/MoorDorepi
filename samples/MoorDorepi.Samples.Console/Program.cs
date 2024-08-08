using Microsoft.Extensions.Configuration;
using MoorDorepi;
using MoorDorepi.Authentication;
using MoorDorepi.Configuration;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var registryUrl = config["registry"];
var username = config["username"];
var password = config["password"];

if (string.IsNullOrWhiteSpace(registryUrl) || string.IsNullOrWhiteSpace(username) ||
    string.IsNullOrWhiteSpace(password))
{
    Console.WriteLine("Please provide registry, username and password in user secrets.");
    return;
}

var configuration = new RegistryClientConfiguration(registryUrl);
var authenticationProvider = new BasicAuthenticationProvider(username, password);
var client = new RegistryClient(configuration, authenticationProvider);

var isAvailable = await client.System.IsAvailableAsync();
Console.WriteLine($"IsAvailable: {isAvailable}");

var (isAvailableWithMessage, errorMessage) = await client.System.IsAvailableWithMessageAsync();
Console.WriteLine($"IsAvailableWithMessage: {isAvailableWithMessage}, ErrorMessage: {errorMessage}");

var catalog = await client.Catalog.GetAsync();
Console.WriteLine(catalog);

if (catalog is null) return;
if (catalog.Repositories.Length == 0) return;

foreach (var repository in catalog.Repositories)
{
    var tags = await client.Tags.GetAsync(repository);
    Console.WriteLine(tags);

    if (tags is null) continue;
    foreach (var tag in tags.Tags)
    {
        var manifest = await client.Manifest.GetRawAsync(repository, tag);
        // Console.WriteLine(manifest);
    }
}