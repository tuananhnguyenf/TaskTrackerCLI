using System;

public class Task(string description)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string Description { get; set; } = description;
    public TaskStatus Status { get; set; } = TaskStatus.TODO;

    private void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeDescription(string newDescription)
    {
        Description = newDescription;

        Update();
    }

    public void ChangeStatus(TaskStatus newStatus)
    {
        Status = newStatus;

        Update();
    }
}
