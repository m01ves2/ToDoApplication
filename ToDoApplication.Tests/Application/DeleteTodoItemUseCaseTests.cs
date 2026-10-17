using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Infrastructure.Repositories;

namespace ToDoApplication.Tests.Application
{
    public class DeleteTodoItemUseCaseTests
    {
        [Fact]
        public void Execute_RemovesItemFromRepository()
        {
            var repo = new InMemoryTodoRepository();
            var item = new TodoItem("Learn TDD");
            repo.Add(item);
            var useCase = new DeleteTodoItemUseCase(repo);

            useCase.Execute(item.Id);

            Assert.Empty(repo.GetAll());
        }
    }
}
