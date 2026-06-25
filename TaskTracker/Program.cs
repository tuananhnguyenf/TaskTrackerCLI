using System;

public static class Program
{
    private static readonly TaskTracker tracker = new();

    private static void HandleAdd(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("No description provided. Exiting...");
            return;
        }

        string description = args[1];

        var newTask = tracker.AddTask(description);
        Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
    }

    private static void HandleList(string[] args)
    {
        IEnumerable<string> tasks;

        if (args.Length == 1)
        {
            tasks = tracker.ListTasks();
        }
        else
        {
            var filter = args[1];

            switch (filter)
            {
                case "todo":
                    tasks = tracker.ListTasks(TaskStatus.TODO);
                    break;
                case "in-progress":
                    tasks = tracker.ListTasks(TaskStatus.IN_PROGRESS);
                    break;
                case "done":
                    tasks = tracker.ListTasks(TaskStatus.DONE);
                    break;
                default:
                    tasks = [];
                    break;
            }
        }


        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    private static void HandleUpdate(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("No ID passed. Exiting...");
            return;
        }

        if (args.Length < 3)
        {
            Console.WriteLine("No new description passed. Exiting...");
            return;
        }

        int taskId;

        try
        {
            taskId = int.Parse(args[1]);
        }
        catch
        {
            Console.WriteLine("[ERROR] ID must be a number. Exiting...");
            return;
        }

        string newDescription = args[2];
        tracker.UpdateTask(taskId, newDescription);
    }

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments passed. Exiting...");
            return;
        }

        string command = args[0].ToLower();

        switch (command)
        {
            case "add":
                HandleAdd(args);
                break;
            case "list":
                HandleList(args);
                break;
            case "update":
                HandleUpdate(args);
                break;
            default:
                Console.WriteLine("Unknown command. Exiting...");
                return;
        }
    }
}
