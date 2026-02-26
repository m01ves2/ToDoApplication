using ToDoApplication.Presentation.Models;

namespace ToDoApplication.Presentation.Interfaces
{
    public interface ITodoView
    {
        event Action<string>? AddButtonClicked;
        event Action<int>? ItemToggleedCompleted;
        void DisplayTodoItems(IEnumerable<TodoItemDto> items);
    }
}
