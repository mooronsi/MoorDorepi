namespace MoorDorepi.Services.Abstractions;

public interface ISystemService
{
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken = default);

    Task<(bool IsAvailable, string ErrorMessage)> IsAvailableWithMessageAsync(
        CancellationToken cancellationToken = default);
}