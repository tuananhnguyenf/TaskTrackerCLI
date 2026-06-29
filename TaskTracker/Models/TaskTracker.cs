using System.Text.Json;

public class TaskTracker
{
    public List<Task> Tasks { get; private set; } = [];

    private const string FILE_NAME = "tasks.json";

    public static int nextId = 1;

    public TaskTracker()
    {
        if (!File.Exists(FILE_NAME))
        {
            using var writer = new StreamWriter(FILE_NAME);
            writer.Write("[]");
        }

        var json = File.ReadAllText(FILE_NAME);

        List<Task>? tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? [];

        Tasks = tasks;

        if (tasks.Count > 0)
        {
            nextId = tasks.Max(task => task.Id) + 1;
        }
    }

    private void WriteToFile()
    {
        using var writer = new StreamWriter(FILE_NAME);
        var jsonString = JsonSerializer.Serialize(Tasks);

        writer.Write(jsonString);
    }

    public Task AddTask(string taskDescription)
    {
        Task newTask = new(taskDescription);

        Tasks.Add(newTask);
        WriteToFile();

        return newTask;
    }

    public void UpdateTask(int taskId, string newDescription)
    {
        Task? foundTask = Tasks.Find(task => task.Id == taskId);

        if (foundTask == null)
        {
            return;
        }

        foundTask.ChangeDescription(newDescription);
        WriteToFile();
    }

    public void DeleteTask(int taskId)
    {
        Tasks = [.. Tasks.Where(task => task.Id != taskId)];
        WriteToFile();
    }

    public void MarkTask(int taskId, TaskStatus newStatus)
    {
        Task? foundTask = Tasks.Find(task => task.Id == taskId);

        if (foundTask == null)
        {
            return;
        }

        foundTask.ChangeStatus(newStatus);
        WriteToFile();
    }

    private static string StatusToString(TaskStatus status)
    {
        switch (status)
        {
            case TaskStatus.TODO:
                return "TODO";
            case TaskStatus.IN_PROGRESS:
                return "IN PROGRESS";
            case TaskStatus.DONE:
                return "DONE";
            default:
                return "";
        }
    }

    public static TaskStatus StringToStatus(string status)
    {
        switch (status)
        {
            case "in-progress":
                return TaskStatus.IN_PROGRESS;
            case "done":
                return TaskStatus.DONE;
            default:
                return TaskStatus.TODO;
        }
    }

    private static string PrintTask(Task task)
    {
        return $"- (ID: {task.Id}) {task.Description}: {StatusToString(task.Status)}";
    }

    public IEnumerable<string> ListTasks()
    {
        return Tasks.Select(PrintTask);
    }

    public IEnumerable<string> ListTasks(TaskStatus filterStatus)
    {
        return Tasks.Where(task => task.Status == filterStatus).Select(PrintTask);
    }
}
