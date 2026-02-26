using ToDoApplication.Application.UseCases;
using ToDoApplication.Presentation.Interfaces;
using ToDoApplication.Presentation.Models;

namespace ToDoApplication.Presentation
{
    public class TodoPresenter
    {
        private readonly ITodoView _view;
        private readonly CreateTodoItemUseCase _createUseCase;
        private readonly GetTodoItemsUseCase _getUseCase;
        private readonly ToggleTodoItemCompletedUseCase _ToggleTodoItemCompletedUseCase;

        public TodoPresenter(
            ITodoView view,
            CreateTodoItemUseCase createUseCase,
            GetTodoItemsUseCase getUseCase,
            ToggleTodoItemCompletedUseCase ToggleTodoItemCompletedUseCase)
        {
            _view = view;
            _createUseCase = createUseCase;
            _getUseCase = getUseCase;
            _ToggleTodoItemCompletedUseCase = ToggleTodoItemCompletedUseCase;

            _view.AddButtonClicked += OnAddButtonClicked;
            _view.ItemToggleedCompleted += OnItemToggleedComplete;

            RefreshList();
        }

        private void OnItemToggleedComplete(int id)
        {
            _ToggleTodoItemCompletedUseCase.Execute(id);
            RefreshList();
        }

        private void OnAddButtonClicked(string title)
        {
            var item = _createUseCase.Execute(title);
            RefreshList();
        }

        private void RefreshList()
        {
            var items = _getUseCase.Execute();
            var dtos = items.Select(i => new TodoItemDto(i.Id, i.Title, i.IsCompleted));
            _view.DisplayTodoItems(dtos);
        }
    }
}
