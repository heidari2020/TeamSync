namespace TeamSync.Api.Domain;
public sealed class User
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    public required string Username { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}