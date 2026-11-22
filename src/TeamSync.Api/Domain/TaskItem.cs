namespace TeamSync.Api.Domain;

public enum TaskStatus
{
    Todo,
    InProgress,
    Done
}

public sealed class TaskItem
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public required string Title { get; init; }
    public string Description { get; init; } = string.Empty;
    public TaskStatus Status { get; private set; } = TaskStatus.Todo;

    public Guid ProjectId { get; init; }
    public Project Project { get; init; } = null!;
    public void ChangeStatus(TaskStatus newStatus) => Status = newStatus;
}