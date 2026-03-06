using ToDoApplication.Application.Interfaces;
using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Infrastructure.Repositories;
using ToDoApplication.Presentation;

namespace ToDoApplication.CompositionRoot
{
    public static class AppBuilder
    {
        //public static Form1 BuildForm()
        //{
        //    // 1. Репозиторий
        //    var repo = new InMemoryTodoRepository();
        //    AddMockData(repo);

        //    // 2. UseCases
        //    var createUseCase = new CreateTodoItemUseCase(repo);
        //    var getUseCase = new GetTodoItemsUseCase(repo);
        //    var ToggleCompletedUseCase = new ToggleCompletedUseCase(repo);
        //    var deleteUseCase = new DeleteTodoItemUseCase(repo);
        //    var deleteAllCompletedUseCase = new DeleteCompletedUseCase(repo);
        //    var swapItemsOrderUsecase = new SwapItemsOrderUseCase(repo);

        //    // 3. Форма
        //    var form = new Form1();

        //    // 4. Presenter
        //    var presenter = new TodoPresenter(  form, 
        //                                        createUseCase, 
        //                                        getUseCase, 
        //                                        ToggleCompletedUseCase, 
        //                                        deleteUseCase, 
        //                                        deleteAllCompletedUseCase,
        //                                        swapItemsOrderUsecase);

        //    return form;
        //}

        public static MainViewModel BuildViewModel()
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
            var mainViewModel = new MainViewModel(getUC, createUC, ToggleCompletedUC, deleteUC, deleteCompletedUC, swapItemsOrderUC);

            return mainViewModel;
        }

        public static void AddMockData(ITodoRepository repo)
        {
            repo.Add(new TodoItem("Get up"));
            repo.Add(new TodoItem("Have a breakfast"));
            repo.Add(new TodoItem("Go to school"));
        }
    }
}
