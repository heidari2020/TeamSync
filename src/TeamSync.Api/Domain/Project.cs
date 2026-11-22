namespace TeamSync.Api.Domain;
public sealed class Project
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public required string Name { get; init; }
    public string Description { get; init; } = string.Empty;
    public Guid OwnerId { get; init; }
    public User Owner { get; init; } = null!;
}