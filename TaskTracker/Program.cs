using System;

public static class Program
{
    private static void HandleAdd(TaskTracker tracker, string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("No description provided. Exiting...");
            return;
        }

        string description = args[1];

        tracker.AddTask(description);
    }

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments passed. Exiting...");
            return;
        }

        TaskTracker tracker = new();

        string command = args[0].ToLower();

        switch (command)
        {
            case "add":
                HandleAdd(tracker, args);
                break;
            default:
                Console.WriteLine("Unknown command. Exiting...");
                return;
        }
    }
}
