using ToDoApplication.Presentation.Models;

namespace ToDoApplication.Presentation.Interfaces
{
    public interface ITodoView
    {
        event Action<string>? AddButtonClicked;
        event Action<int>? ItemToggledCompleted;
        event Action<int>? DeleteButtonClicked;
        event Action? DeleteCompletedButtonClicked;
        event Action<int, int>? SwapButtonUpClicked;
        event Action<int, int>? SwapButtonDownClicked;
        void DisplayTodoItems(IEnumerable<TodoItemDto> items);
        void ShowError(string message);
    }
}
