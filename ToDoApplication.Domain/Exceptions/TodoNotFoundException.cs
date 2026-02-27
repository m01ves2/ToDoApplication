namespace ToDoApplication.Domain.Exceptions
{
    public class TodoNotFoundException : Exception
    {
        public int TodoItemId { get; }

        public TodoNotFoundException(int id) : base($"Todo with id {id} was not found.")
        {
            TodoItemId = id;
        }
    }
}
