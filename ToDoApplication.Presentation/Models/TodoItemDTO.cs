namespace ToDoApplication.Presentation.Models
{
    public class TodoItemDto
    {
        public int Id { get; }
        public string Title { get; }
        public bool IsCompleted { get; }

        public TodoItemDto(int id, string title, bool isCompleted)
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
