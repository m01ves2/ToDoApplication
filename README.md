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

### Running the application

Set `ToDoApplication.WPF` as the Startup Project in Visual Studio and press F5.


## Notes
- MainViewModel orchestrates UI and UseCases  
- Commands handle all interactions  
- Currently uses in-memory repository; database persistence can be added later

### MVVM Implementation

The application uses the Model-View-ViewModel (MVVM) pattern.

- **View (`MainWindow.xaml`)** defines the user interface and uses WPF data binding.
- **ViewModel (`MainViewModel`)** exposes UI state, task collections, and commands.
- **Model (`TodoItem`)** represents the domain entity and contains domain behavior.

The View is connected to `MainViewModel` through `DataContext`.

`INotifyPropertyChanged` notifies the UI about property changes, while `ObservableCollection<T>` notifies WPF about changes to the task collection.

User actions are handled through `ICommand`, implemented by `RelayCommand`, rather than through button event handlers in the View's code-behind.

After executing Use Cases, `MainViewModel` reloads the tasks from the repository and updates the observable collection.

Unlike the WinForms/MVP implementation, ViewModel does not hold a reference to View or call its rendering methods directly.