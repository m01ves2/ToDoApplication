using ToDoApplication.Application.Interfaces;
using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Infrastructure.Repositories;
using ToDoApplication.Presentation;
using ToDoApplication.WinForms;

namespace ToDoApplication.CompositionRoot
{
    public static class AppBuilder
    {
        public static Form1 BuildForm()
        {
            // 1. Репозиторий
            var repo = new InMemoryTodoRepository();
            AddMockData(repo);

            // 2. UseCases
            var createUseCase = new CreateTodoItemUseCase(repo);
            var getUseCase = new GetTodoItemsUseCase(repo);
            var ToggleCompletedUseCase = new ToggleTodoItemCompletedUseCase(repo);
            var deleteUseCase = new DeleteTodoItemUseCase(repo);
            var deleteAllCompletedUseCase = new DeleteCompletedUseCase(repo);
            var swapItemsOrderUsecase = new SwapItemsOrderUseCase(repo);

            // 3. Форма
            var form = new Form1();

            // 4. Presenter
            var presenter = new TodoPresenter(  form, 
                                                createUseCase, 
                                                getUseCase, 
                                                ToggleCompletedUseCase, 
                                                deleteUseCase, 
                                                deleteAllCompletedUseCase,
                                                swapItemsOrderUsecase);

            return form;
        }

        public static void AddMockData(ITodoRepository repo)
        {
            repo.Add(new TodoItem("Get up"));
            repo.Add(new TodoItem("Have a breakfast"));
            repo.Add(new TodoItem("Go to school"));
        }
    }
}
