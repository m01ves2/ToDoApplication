using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.UseCases
{
    public class MarkTodoItemCompletedUseCase
    {
        private readonly ITodoItemRepository _repo;
        public MarkTodoItemCompletedUseCase(ITodoItemRepository repo)
        {
            _repo = repo;
        }

        public void Execute(TodoItem item)
        {
            item.MarkCompleted();
        }
    }
}
