using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.Interfaces
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        void Remove(TodoItem item);
        void RemoveCompleted();
        IReadOnlyList<TodoItem> GetAll();
        TodoItem? GetById(int id);
    }
}
