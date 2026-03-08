using ToDoApplication.Application.Interfaces;
using ToDoApplication.Application.UseCases;
using ToDoApplication.CLI;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Infrastructure.Repositories;
using ToDoApplication.Presentation;

namespace ToDoApplication.CompositionRoot
{
    public class AppBuilder
    {
        public void Run()
        {
            // 1. Репозиторий
            var repo = new InMemoryTodoRepository();
            AddMockData(repo);

            // 2. UseCases
            var createUC = new CreateTodoItemUseCase(repo);
            var getUC = new GetTodoItemsUseCase(repo);
            var ToggleCompletedUC = new ToggleCompletedUseCase(repo);
            var deleteUC = new DeleteTodoItemUseCase(repo);
            var deleteCompletedUC = new DeleteCompletedUseCase(repo);
            var swapItemsOrderUC = new SwapItemsOrderUseCase(repo);

            // 3. Presentation
            var viewModel = new ConsoleViewModel(getUC, createUC, ToggleCompletedUC, deleteUC, deleteCompletedUC, swapItemsOrderUC);
            var view = new ConsoleView();

            // 4. wiring
            viewModel.TodosChanged += view.Render;
            viewModel.ErrorOccurred += view.ShowError;
            view.AddTodoRequested += viewModel.AddTodo;
            view.DeleteTodoRequested += viewModel.DeleteTodo;
            view.ToggleCompletedRequested += viewModel.ToggleCompletedTodo;
            view.DeleteCompleted += viewModel.DeleteCompleted;
            view.MoveUpRequested += viewModel.MoveUp;
            view.MoveDownRequested += viewModel.MoveDown;

            viewModel.Initialize();
            view.Run();
        }

        public static void AddMockData(ITodoRepository repo)
        {
            repo.Add(new TodoItem("Get up"));
            repo.Add(new TodoItem("Have a breakfast", true));
            repo.Add(new TodoItem("Go to school", true));
        }
    }
}
