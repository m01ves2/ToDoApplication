using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.UseCases
{
    public class GetTodoItemsUseCase
    {
        private readonly ITodoItemRepository _repo;

        public GetTodoItemsUseCase(ITodoItemRepository repo)
        {
            _repo = repo;
        }

        public IReadOnlyList<TodoItem> Execute()
        {
            return _repo.GetAll();
        }
    }
}
