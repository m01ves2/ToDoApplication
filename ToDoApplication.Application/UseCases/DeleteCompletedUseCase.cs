using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Exceptions;

namespace ToDoApplication.Application.UseCases
{
    public class DeleteCompletedUseCase
    {
        private readonly ITodoRepository _repo;

        public DeleteCompletedUseCase(ITodoRepository repo)
        {
            _repo = repo;
        }

        public void Execute()
        {
            _repo.RemoveCompleted();
        }
    }
}
