using ToDoApplication.Application.Interfaces;
using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Application.UseCases
{
    public class SwapItemsOrderUseCase
    {
        private readonly ITodoRepository _repo;

        public SwapItemsOrderUseCase(ITodoRepository repo)
        {
            _repo = repo;
        }

        public void Execute(int id1, int id2)
        {
            TodoItem? item1 = _repo.GetById(id1);
            TodoItem? item2 = _repo.GetById(id2);
            if (item1 == null || item2 == null)
                return;

            _repo.SwapOrders(item1, item2);
        }
    }
}
