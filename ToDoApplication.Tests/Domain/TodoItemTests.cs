using ToDoApplication.Domain.Entities;

namespace ToDoApplication.Tests.Domain
{
    public class TodoItemTests
    {
        [Fact]
        public void Create_WithValidTitle_SetsTitleAndIsNotCompleted()
        {
            var task = new TodoItem("Learn TDD");

            Assert.Equal("Learn TDD", task.Title);
            Assert.False(task.IsCompleted);
        }

        [Fact]
        public void Create_WithNullTitle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new TodoItem(null));
        }

        [Fact]
        public void ToggleCompleted_SetsIsCompletedToTrue()
        {
            var task = new TodoItem("Learn TDD");
            task.ToggleCompleted();
            Assert.True(task.IsCompleted);
        }
    }
}
