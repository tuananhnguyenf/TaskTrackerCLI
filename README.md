# Task Tracker CLI

This is a simple task tracker CLI app taken from [the developer roadmaps' backend projects list](https://roadmap.sh/projects/task-tracker).
This project was solely for me to try out C# basics.

## How to run

Change your working directory to `TaskTracker/`.

```bash
cd TaskTracker
```

To run, use

```bash
dotnet run [command] [argument]
```

### List of commands

#### Add

```bash
add [task description]
```

Adds a new task with a given description.

#### Update

```bash
update [task ID] [new description]
```

Updates a task with a given ID with a new description.

#### Mark

```bash
mark-in-progress [task ID]
```

Marks a task with a given ID as in progress.

```bash
mark-done [task ID]
```

Marks a task with a given ID as done.

```bash
mark-todo [task ID]
```

Marks a task with a given ID as todo.

#### List

```bash
list
```

Lists all tasks.

```bash
list done
```

Lists all tasks marked as done.

```bash
list todo
```

lists all tasks marked as todo.

```bash
list in-progress
```

Lists all tasks marked as in progress.

## Description

A simple CLI task tracker application. The tasks are saved in a JSON file.
Each task has the following properties:

- `id`: a unique identifier for the task. Previously `Guid` but changed to sequential numbering for better user accessibility
- `description`: a short description of the task
- `status`: the status of the task (`todo`, `in-progress`, `done`)
- `createdAt`: a timestamp of when the task was created
- `updatedAt`: a timestamp of when the task was last updated
