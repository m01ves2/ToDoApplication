using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Infrastructure.Repositories
{
    public class InMemoryTodoItemRepository : ITodoItemRepository
    {
        private readonly List<TodoItem> _items = new List<TodoItem>();

        public void Add(TodoItem item)
        {
            _items.Add(item);
        }

        public IReadOnlyList<TodoItem> GetAll()
        {
            return _items;
        }

        public void Remove(TodoItem item)
        {
            _items.Remove(item);
        }
    }
}
