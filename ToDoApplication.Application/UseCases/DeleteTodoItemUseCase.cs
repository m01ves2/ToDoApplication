using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.UseCases
{
    public class DeleteTodoItemUseCase
    {
        private readonly ITodoItemRepository _repo;

        public DeleteTodoItemUseCase(ITodoItemRepository repo)
        {
            _repo = repo;
        }

        public void Execute(TodoItem item)
        {
            _repo.Remove(item);
        }
    }
}
