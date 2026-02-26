using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Infrastructure.Repositories
{
    public class InMemoryTodoRepository : ITodoItemRepository
    {
        private readonly List<TodoItem> _items = new List<TodoItem>();
        private int _nextIndex = 0;
        public void Add(TodoItem item)
        {
            _nextIndex++;
            item.Id = _nextIndex;
            _items.Add(item);
        }

        public IReadOnlyList<TodoItem> GetAll()
        {
            return _items;
        }

        public TodoItem? GetById(int id)
        {
            return _items.Find(x => x.Id == id);
        }

        public void Remove(TodoItem item)
        {
            _items.Remove(item);
        }
    }
}
