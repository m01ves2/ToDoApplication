using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Infrastructure.Repositories;

namespace ToDoApplication.Tests.Application
{
    public class MarkTodoItemCompletedUseCaseTests
    {
        [Fact]
        public void Execute_SetsIsCompletedToTrue()
        {
            var repo = new InMemoryTodoItemRepository();
            var item = new TodoItem("Learn TDD");
            repo.Add(item);
            var useCase = new MarkTodoItemCompletedUseCase(repo);

            useCase.Execute(item);

            Assert.True(item.IsCompleted);
            Assert.Contains(item, repo.GetAll());
        }
    }
}
