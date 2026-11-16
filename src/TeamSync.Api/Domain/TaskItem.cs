namespace TeamSync.Api.Domain;

public enum TaskStatus
{
    Todo,
    InProgress,
    Done
}

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.Todo;
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}
