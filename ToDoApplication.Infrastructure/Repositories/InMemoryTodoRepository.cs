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
            int id = ++_nextId;
            item.SetId(id);
            //item.SetOrder(_items.Count == 0 ? 1 : _items.Max(i => i.Order) + 1);
            item.SetOrder(id); 
            _items.Add(item);
        }

        public IReadOnlyList<TodoItem> GetAll()
        {
            return _items.OrderBy(i => i.Order).ToList();
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

        public void SwapOrders(TodoItem item1, TodoItem item2)
        {
            int tmp = item1.Order;
            item1.SetOrder(item2.Order);
            item2.SetOrder(tmp);
        }
    }
}
