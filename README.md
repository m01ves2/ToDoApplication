# To-Do Application - MVP & MVVM Architecture Lab

An educational project built with **C# 12 / .NET 8**, exploring different approaches to UI architecture through three independent implementations of a To-Do application.

The project demonstrates how presentation logic can be separated from UI rendering using **MVP**, **MVVM**, and manually configured events and delegates.

## Implementations

| Phase | Technology | Architecture | Branch |
|---|---|---|---|
| 1 | WinForms | MVP (Passive View) | https://github.com/m01ves2/ToDoApplication/tree/phase/1-winforms-mvp |
| 2 | WPF | MVVM | https://github.com/m01ves2/ToDoApplication/tree/phase/2-wpf-mvvm |
| 3 | Console UI | MVVM-like | https://github.com/m01ves2/ToDoApplication/tree/phase/3-console-mvvm |

Each phase is preserved in a separate Git branch and contains its own application, tests, and README.

The **`main` branch serves as the documentation and navigation hub**. It does not contain application source code.

## Features

All three implementations support:

- Creating and displaying tasks.
- Toggling task completion.
- Deleting individual tasks.
- Deleting all completed tasks.
- Moving tasks up and down in the list.

Tasks are stored using an in-memory repository and are not persisted between application runs.

## Getting Started

Requirements:

- Git
- .NET 8 SDK
- Windows for WinForms and WPF

Clone the repository:

```bash
git clone https://github.com/m01ves2/ToDoApplication
cd ToDoApplication
```

Switch to the implementation you want to explore:

**Phase 1 — WinForms MVP**

```bash
git switch phase/1-winforms-mvp
```

**Phase 2 — WPF MVVM**

```bash
git switch phase/2-wpf-mvvm
```

**Phase 3 — Console MVVM-like**

```bash
git switch phase/3-console-mvvm
```

Each branch provides its own README with build and run instructions.

To return to the documentation:

```bash
git switch main
```

## MVP vs MVVM — Key Takeaways

### Phase 1 — WinForms / MVP

- The View handles user interaction and raises events.
- Presenter subscribes to View events and invokes Application Use Cases.
- Presenter explicitly updates the View through the `ITodoView` interface.
- Presenter can be tested using a fake implementation of `ITodoView`.
- The View does not contain application business logic.

### Phase 2 — WPF / MVVM

- View and ViewModel are connected through `DataContext` and WPF Binding.
- `INotifyPropertyChanged` notifies the UI about property changes.
- `ObservableCollection<T>` notifies the UI about collection changes.
- `ICommand` connects user actions to ViewModel behavior.
- ViewModel exposes state and commands without directly manipulating visual controls.

### Phase 3 — Console / MVVM-like

- View handles user input and raises custom events.
- ViewModel invokes Use Cases and maintains the task data presented to the UI.
- Composition Root configures event subscriptions in both directions.
- ViewModel publishes updated state without calling View methods directly.
- ConsoleView receives updates and manually redraws the interface.
- The implementation demonstrates MVVM-inspired separation without a framework-provided Binding Engine.

## Architecture Comparison

| Aspect | WinForms MVP | WPF MVVM | Console MVVM-like |
|---|---|---|---|
| Presentation component | Presenter | MainViewModel | ConsoleViewModel |
| User interaction | View events | Commands and Binding | Custom View events |
| UI updates | Explicit Presenter calls | WPF Binding | Custom events |
| View reference in presentation component | `ITodoView` | None | None |
| Automatic data binding | No | Yes | No |
| Task list updates | Explicit refresh | ObservableCollection | Console redraw |

## Conclusions

MVP and MVVM are different approaches to separating UI rendering from presentation logic.

**Neither pattern is universally better.** Both can provide good separation of concerns, maintainability, and testability.

MVP makes communication explicit: the Presenter responds to View events and instructs the View to update through an interface.

MVVM emphasizes exposing state and behavior through properties and commands. A compatible UI framework, such as WPF, can synchronize this state with visual controls through data binding.

The Console MVVM-like experiment demonstrates what happens when such infrastructure is unavailable: application state changes must be communicated explicitly, using events and delegates.

The most important lesson of the project is that **a UI framework does not eliminate communication between components — it provides mechanisms that organize and automate it**.

## Review — October 2026

The three implementations were revisited approximately six months after their original development.

The review focused on reconstructing architectural decisions, understanding component communication, identifying design trade-offs, and correcting implementation defects.

### Phase 1 — WinForms MVP

- Reviewed the interaction between View, Presenter, and Application Use Cases.
- Revisited Dependency Inversion and the purpose of `ITodoView`.
- Improved Presenter error handling and UI refresh behavior.
- Fixed outdated unit tests.
- Removed obsolete Playground code that no longer compiled.

### Phase 2 — WPF MVVM

- Reviewed `DataContext`, Binding, `INotifyPropertyChanged`, `ObservableCollection<T>`, and `ICommand`.
- Examined the difference between collection notifications and individual property notifications.
- Fixed outdated tests and a nullable initialization warning.
- Retained the simple full-list reload strategy as an intentional trade-off.

### Phase 3 — Console MVVM-like

- Reviewed bidirectional communication through events and delegates.
- Clarified the distinction between task `Id`, list position, and the `Order` property.
- Fixed task identification and boundary handling in `MoveDown`.
- Resolved nullable warnings in tests.
- Retained the minimal console interface, since the goal was architectural experimentation rather than UI usability.

### Repository Organization

After the review, each implementation was preserved in an independent `phase/*` branch.

The `main` branch was converted into a documentation hub to make the three architectural approaches easier to explore and compare.

Each implementation can be built and studied independently, without introducing unnecessary dependencies between the different UI versions.