using MoorDorepi.Models;

namespace MoorDorepi.Services.Abstractions;

public interface ITagsService
{
    Task<ImageTags?> GetAsync(string repositoryName, CancellationToken cancellationToken = default);
}