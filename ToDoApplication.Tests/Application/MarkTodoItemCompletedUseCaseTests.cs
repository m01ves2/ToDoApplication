using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Infrastructure.Repositories;

namespace ToDoApplication.Tests.Application
{
    public class ToggleTodoItemCompletedUseCaseTests
    {
        [Fact]
        public void Execute_SetsIsCompletedToTrue()
        {
            var repo = new InMemoryTodoRepository();
            var item = new TodoItem("Learn TDD");
            repo.Add(item);
            var useCase = new ToggleCompletedUseCase(repo);

            useCase.Execute(item);

            Assert.True(item.IsCompleted);
            Assert.Contains(item, repo.GetAll());
        }
    }
}
