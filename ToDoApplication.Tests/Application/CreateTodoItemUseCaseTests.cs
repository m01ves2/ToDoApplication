using ToDoApplication.Application.UseCases;
using ToDoApplication.Infrastructure.Repositories;

namespace ToDoApplication.Tests.Application
{
    public class CreateTodoItemUseCaseTests
    {
        [Fact]
        public void Execute_WithValidTitle_AddsTodoItemToRepository()
        {
            // Arrange
            var repo = new InMemoryTodoItemRepository();
            var useCase = new CreateTodoItemUseCase(repo);

            // Act
            var item = useCase.Execute("Learn TDD");

            // Assert
            Assert.Single(repo.GetAll());
            Assert.Equal("Learn TDD", item.Title);
            Assert.False(item.IsCompleted);
        }

        [Fact]
        public void Execute_WithNullOrEmptyTitle_ThrowsException()
        {
            // Arrange
            var repo = new InMemoryTodoItemRepository();
            var useCase = new CreateTodoItemUseCase(repo);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => useCase.Execute(null));
            Assert.Throws<ArgumentException>(() => useCase.Execute(""));
            Assert.Throws<ArgumentException>(() => useCase.Execute("   "));
        }
    }
}
