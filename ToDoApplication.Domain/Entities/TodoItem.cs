namespace ToDoApplication.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; }
        public bool IsCompleted { get; private set; }
        public TodoItem(string title) {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty", nameof(title));

            Title = title;
            IsCompleted = false;
        }

        public void ToggleComplete()
        {
            IsCompleted = !IsCompleted;
        }
    }
}
