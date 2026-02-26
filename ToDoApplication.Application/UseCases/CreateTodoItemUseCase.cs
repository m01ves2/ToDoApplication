using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.UseCases
{
    public class CreateTodoItemUseCase
    {
        private readonly ITodoItemRepository _repo;

        public CreateTodoItemUseCase(ITodoItemRepository repo)
        {
            _repo = repo;
        }

        public TodoItem Execute(string title)
        {
            TodoItem todoItem = new TodoItem(title);
            _repo.Add(todoItem);
            return todoItem;
        }
    }
}
