namespace ToDoApplication.Presentation.Models
{
    public class TodoItemDTO
    {
        public int Id { get; }
        public string Title { get; }
        public int Order { get; }
        public bool IsCompleted { get; }

        public TodoItemDTO(int id, string title, int order, bool isCompleted)
        {
            Id = id;
            Title = title;
            Order = order;
            IsCompleted = isCompleted;
        }
    }
}
