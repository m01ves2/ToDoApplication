# ToDoApplication

Simple To-Do app in **C# / WPF**( **MVVM** pattern) and **WinForms** (**MVP** pattern).

## Features
- Add, toggle, delete, and reorder tasks
- Delete completed tasks
- ObservableCollection for dynamic UI updates
- Unit-tested UseCases and Domain logic

## Technologies
- C# 12, .NET 8
- WPF, Console and Winforms for UI
- MVP design pattern 
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
3. Build & run `ToDoApplication.WPF`/`ToDoApplication.CLI`/`ToDoApplication.Winforms`

## Notes
- MainViewModel orchestrates UI and UseCases  
- Commands handle all interactions  
- Currently uses in-memory repository; database persistence can be added later


# To-Do Application (WPF MVVM + Console MVVM + Winforms MVP)

This project demonstrates a simple To-Do application built using **MVVM architecture** and **MVP architecture**. The WPF version uses full data binding,
 while the Console version mimics MVVM with events and DTOs to separate View and ViewModel. The exercise shows how MVVM concepts can be applied even without a UI framework, emphasizing state-driven updates and decoupled design.

## MVVM vs MVP - Key Takeaways

- **MVVM decouples the View from the logic:** ViewModel holds state and notifies subscribers; View only reacts to events. No direct calls between View and ViewModel.  
- **MVP binds View and Presenter more tightly:** Presenter actively manipulates the View, often calling methods or updating controls directly.  
- **MVVM enables cleaner separation and easier testing:** State changes propagate via events; UI updates automatically.  
- **In a console or non-WPF UI, MVVM concepts still apply:** Use events and DTOs to mimic binding without framework-specific features.  

**Conclusion:** While both patterns work, MVVM provides a more flexible and testable architecture by separating state management from UI rendering.
MVP is simpler for small apps. MVVM keeps UI and logic separated, updates views automatically via events/bindings, and scales better for complex applications. 
This project shows MVVM principles using a console UI and WPF, and MVP principles using WinForms.