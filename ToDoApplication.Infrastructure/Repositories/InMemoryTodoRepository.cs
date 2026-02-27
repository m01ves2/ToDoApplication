using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Infrastructure.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _items = new List<TodoItem>();
        private int _nextId = 0;
        public void Add(TodoItem item)
        {
            item.SetId(_nextId++);
            _items.Add(item);
        }

        public IReadOnlyList<TodoItem> GetAll()
        {
            return _items;
        }

        public TodoItem? GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(TodoItem item)
        {
            _items.Remove(item);
        }

        public void RemoveCompleted()
        {
            _items.RemoveAll(t => t.IsCompleted);
        }
    }
}
