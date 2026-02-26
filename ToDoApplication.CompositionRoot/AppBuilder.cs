using ToDoApplication.Application.UseCases;
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

            // 2. UseCases
            var createUseCase = new CreateTodoItemUseCase(repo);
            var getUseCase = new GetTodoItemsUseCase(repo);
            var ToggleCompletedUseCase = new ToggleTodoItemCompletedUseCase(repo);
            var deleteUseCase = new DeleteTodoItemUseCase(repo);

            // 3. Форма
            var form = new Form1();

            // 4. Presenter
            var presenter = new TodoPresenter(form, createUseCase, getUseCase, ToggleCompletedUseCase);

            return form;
        }
    }
}
