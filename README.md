# ToDoApplication

Simple To-Do app in **C# / WPF** with **MVVM** pattern.

## Features
- Add, toggle, delete, and reorder tasks
- Delete completed tasks
- ObservableCollection for dynamic UI updates
- Unit-tested UseCases and Domain logic

## Technologies
- C# 12, .NET 8
- WPF for UI
- MVVM design pattern
- xUnit for testing

## Architecture
- **Presentation:** MainViewModel, TodoItemViewModel, RelayCommand  
- **Application:** UseCases (Create, Get, Toggle, Delete, Swap, DeleteCompleted)  
- **Domain:** TodoItem, TodoNotFoundException  
- **Infrastructure:** InMemoryTodoRepository

## Getting Started
1. Clone repository
2. Open in Visual Studio / Rider
3. Build & run `ToDoApplication.WPF`

## Notes
- MainViewModel orchestrates UI and UseCases  
- Commands handle all interactions  
- Currently uses in-memory repository; database persistence can be added later