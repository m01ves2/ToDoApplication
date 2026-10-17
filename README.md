# To-Do Application — Console MVVM-like

A simple To-Do application built with **C# 12 / .NET 8**, using a console interface and an event-driven presentation architecture inspired by the MVVM pattern.

## Features

- Create and display tasks.
- Toggle task completion.
- Delete individual or all completed tasks.
- Move tasks up and down in the list.

Tasks are stored in memory and are not persisted between runs.

## Technologies

- C# 12 / .NET 8
- Console UI
- Events and delegates
- Layered architecture
- xUnit for unit testing

## Architecture

| Project | Responsibility |
|---|---|
| `ToDoApplication.Domain` | `TodoItem` entity and domain rules |
| `ToDoApplication.Application` | Use Cases and `ITodoRepository` |
| `ToDoApplication.Infrastructure` | `InMemoryTodoRepository` |
| `ToDoApplication.Presentation` | `ConsoleViewModel` and `TodoItemDTO` |
| `ToDoApplication.CLI` | `ConsoleView` — user input and rendering |
| `ToDoApplication.CompositionRoot` | Object creation and event subscriptions |
| `ToDoApplication.Tests` | Unit tests |

## Presentation Architecture

`ConsoleView` handles user input and raises events such as `AddTodoRequested` and `DeleteTodoRequested`.

`ConsoleViewModel` handles these requests through Application Use Cases, retrieves the current tasks, and raises `TodosChanged` when the displayed data needs updating.

`AppBuilder` connects View and ViewModel through delegates:

```csharp
view.AddTodoRequested += viewModel.AddTodo;
viewModel.TodosChanged += view.Render;
```

The View and ViewModel do not hold direct references to each other.

Unlike a full MVVM framework, this implementation uses manually configured events rather than an automatic data binding mechanism.

## Build and Run

Requires .NET 8 SDK.

```bash
dotnet build
dotnet test
dotnet run --project ToDoApplication.CompositionRoot
```

## Notes

- `ConsoleViewModel` coordinates UI operations and Application Use Cases.
- `TodoItemDTO` represents the task data passed to the console interface.
- The View redraws the task list after receiving `TodosChanged`.
- The interface is intentionally minimal, focusing on presentation architecture rather than advanced console UI features.