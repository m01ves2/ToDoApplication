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
        private readonly DeleteTodoItemUseCase _deleteTodoItemUseCase;
        private readonly DeleteCompletedUseCase _deleteCompletedUseCase;

        public TodoPresenter(
            ITodoView view,
            CreateTodoItemUseCase createUseCase,
            GetTodoItemsUseCase getUseCase,
            ToggleTodoItemCompletedUseCase ToggleTodoItemCompletedUseCase,
            DeleteTodoItemUseCase deleteTodoItemUseCase,
            DeleteCompletedUseCase deleteAllUseCase)
        {
            _view = view;
            _createUseCase = createUseCase;
            _getUseCase = getUseCase;
            _ToggleTodoItemCompletedUseCase = ToggleTodoItemCompletedUseCase;
            _deleteTodoItemUseCase = deleteTodoItemUseCase;
            _deleteCompletedUseCase = deleteAllUseCase;

            _view.AddButtonClicked += OnAddButtonClicked;
            _view.ItemToggleedCompleted += OnItemToggleedComplete;
            _view.DeleteButtonClicked += OnDeleteButtonClicked;
            _view.DeleteCompletedButtonClicked += OnDeleteCompletedButtonClicked;
            RefreshList();
        }

        private void OnDeleteCompletedButtonClicked()
        {
            _deleteCompletedUseCase.Execute();
            RefreshList();
        }

        private void OnAddButtonClicked(string title)
        {
            var item = _createUseCase.Execute(title);
            RefreshList();
        }

        private void OnDeleteButtonClicked(int id)
        {

            _deleteTodoItemUseCase.Execute(id);
            RefreshList();
        }

        private void OnItemToggleedComplete(int id)
        {
            _ToggleTodoItemCompletedUseCase.Execute(id);
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
