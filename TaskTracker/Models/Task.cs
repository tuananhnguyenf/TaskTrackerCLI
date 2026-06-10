using System;

public class Task(string description)
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public string Description { get; private set; } = description;
    public TaskStatus Status { get; private set; } = TaskStatus.TODO;

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
