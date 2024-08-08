namespace MoorDorepi.Authentication;

public abstract class AuthenticationProvider
{
    public abstract void Apply(ref HttpClient client);
}