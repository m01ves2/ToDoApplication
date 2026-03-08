namespace ToDoApplication.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public string Title { get; }
        public bool IsCompleted { get; private set; }
        
        public int Order { get; private set; }
        public TodoItem(string title, bool isCompleted = false) {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty", nameof(title));

            Title = title;
            IsCompleted = isCompleted;
        }

        public void ToggleComplete()
        {
            IsCompleted = !IsCompleted;
        }

        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetOrder(int order)
        {
            Order = order;
        }
    }
}
