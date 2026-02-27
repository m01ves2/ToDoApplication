using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.Interfaces
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        void Remove(TodoItem item);
        void RemoveCompleted();

        void SwapOrders(TodoItem item1, TodoItem item2);
        IReadOnlyList<TodoItem> GetAll();
        TodoItem? GetById(int id);
    }
}
