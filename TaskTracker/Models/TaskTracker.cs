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

    public void AddTask(string taskDescription)
    {
        Task newTask = new(taskDescription);

        Tasks.Add(newTask);
        WriteToFile();
    }
}
