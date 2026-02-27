namespace ToDoApplication.Presentation.Models
{
    public class TodoItemDto
    {
        public int Id { get; }
        public string Title { get; }
        public bool IsCompleted { get; }

        public int Order {  get; }
        public TodoItemDto(int id, string title, bool isCompleted, int order)
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
            Order = order;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
