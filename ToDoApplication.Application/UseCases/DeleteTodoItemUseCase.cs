using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Domain.Exceptions;

namespace ToDoApplication.Application.UseCases
{
    public class DeleteTodoItemUseCase
    {
        private readonly ITodoRepository _repo;

        public DeleteTodoItemUseCase(ITodoRepository repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            var item = _repo.GetById(id);

            if (item is null)
                throw new TodoNotFoundException(id);

            _repo.Remove(item);
        }
    }
}
