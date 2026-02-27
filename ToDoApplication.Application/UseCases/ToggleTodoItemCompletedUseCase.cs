using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.UseCases
{
    public class ToggleCompletedUseCase
    {
        private readonly ITodoRepository _repo;
        public ToggleCompletedUseCase(ITodoRepository repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            var item = _repo.GetById(id);

            if (item == null) {
                throw new ArgumentException();
            }
            item.ToggleComplete();
        }
    }
}
