using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.Interfaces
{
    public interface ITodoItemRepository
    {
        void Add(TodoItem item);
        void Remove(TodoItem item);
        IReadOnlyList<TodoItem> GetAll();
        TodoItem? GetById(int id);
    }
}
