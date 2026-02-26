using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Infrastructure.Repositories;

namespace ToDoApplication.Tests.Application
{
    public class GetTodoItemsUseCaseTests
    {
        [Fact]
        public void Execute_ReturnsAllItems()
        {
            var repo = new InMemoryTodoRepository();
            var item1 = new TodoItem("Task 1");
            var item2 = new TodoItem("Task 2");
            repo.Add(item1);
            repo.Add(item2);
            var useCase = new GetTodoItemsUseCase(repo);

            var items = useCase.Execute();

            Assert.Equal(2, items.Count);
            Assert.Contains(item1, items);
            Assert.Contains(item2, items);
        }
    }
}
