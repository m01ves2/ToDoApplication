using ToDoApplication.Presentation.Models;

namespace ToDoApplication.Presentation.Interfaces
{
    public interface ITodoView
    {
        event Action<string>? AddButtonClicked;
        event Action<int>? ItemToggleedCompleted;
        event Action<int>? DeleteButtonClicked;
        public event Action DeleteCompletedButtonClicked;
        void DisplayTodoItems(IEnumerable<TodoItemDto> items);
    }
}
