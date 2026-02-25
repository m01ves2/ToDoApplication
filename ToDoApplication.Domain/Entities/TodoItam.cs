namespace ToDoApplication.Domain.Entities
{
    public class TodoItam
    {
        //public int Id { get; private set; }
        public string Title { get; }
        public bool IsCompleted { get; private set; }
        public TodoItam(string title) {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty", nameof(title));

            Title = title;
            IsCompleted = false;
        }

        public void MarkCompleted()
        {
            IsCompleted = true;
        }
    }
}
