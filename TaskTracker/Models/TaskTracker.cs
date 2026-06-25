using System.Text.Json;

public class TaskTracker
{
    public List<Task> Tasks { get; private set; } = [];

    private const string FILE_NAME = "tasks.json";


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

    private static string StatusToString(TaskStatus status)
    {
        switch (status)
        {
            case TaskStatus.TODO:
                return "TODO";
            case TaskStatus.IN_PROGRESS:
                return "IN_PROGRESS";
            case TaskStatus.DONE:
                return "DONE";
            default:
                return "";
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
