using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Entities;
using ToDoApplication.Presentation.Interfaces;
using ToDoApplication.Presentation.Models;

namespace ToDoApplication.Presentation
{
    public class TodoPresenter
    {
        private readonly ITodoView _view;
        private readonly CreateTodoItemUseCase _createUseCase;
        private readonly GetTodoItemsUseCase _getUseCase;
        private readonly ToggleCompletedUseCase _toggleCompletedUseCase;
        private readonly DeleteTodoItemUseCase _deleteUseCase;
        private readonly DeleteCompletedUseCase _deleteCompletedUseCase;
        private readonly SwapItemsOrderUseCase _swapOrderUseCase;

        public TodoPresenter(
            ITodoView view,
            CreateTodoItemUseCase createUseCase,
            GetTodoItemsUseCase getUseCase,
            ToggleCompletedUseCase toggleCompletedUseCase,
            DeleteTodoItemUseCase deleteUseCase,
            DeleteCompletedUseCase deleteAllUseCase,
            SwapItemsOrderUseCase swapOrderUseCase)
        {
            _view = view;
            _createUseCase = createUseCase;
            _getUseCase = getUseCase;
            _toggleCompletedUseCase = toggleCompletedUseCase;
            _deleteUseCase = deleteUseCase;
            _deleteCompletedUseCase = deleteAllUseCase;
            _swapOrderUseCase = swapOrderUseCase;

            SubscribeToViewEvents();
            RefreshList();
        }

        private void SubscribeToViewEvents()
        {
            _view.AddButtonClicked += OnAddButtonClicked;
            _view.ItemToggledCompleted += OnItemToggledCompleted;
            _view.DeleteButtonClicked += OnDeleteButtonClicked;
            _view.DeleteCompletedButtonClicked += OnDeleteCompletedClicked;
            _view.SwapButtonUpClicked += OnSwapButtonClicked;
            _view.SwapButtonDownClicked += OnSwapButtonClicked;
        }

        private void OnAddButtonClicked(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return;

            ExecuteAndRefresh(() => _createUseCase.Execute(title));
        }

        private void OnDeleteButtonClicked(int id)
        {
            ExecuteAndRefresh(() => _deleteUseCase.Execute(id));
        }

        private void OnDeleteCompletedClicked()
        {
            ExecuteAndRefresh(() => _deleteCompletedUseCase.Execute());
        }

        private void OnItemToggledCompleted(int id)
        {
            ExecuteAndRefresh(() => _toggleCompletedUseCase.Execute(id));
        }

        private void OnSwapButtonClicked(int id1, int id2)
        {
            ExecuteAndRefresh(() => _swapOrderUseCase.Execute(id1, id2));
        }

        private void RefreshList()
        {
            var items = _getUseCase.Execute();
            var dtos = ConvertToDto(items);
            _view.DisplayTodoItems(dtos);
        }

        private IEnumerable<TodoItemDto> ConvertToDto(IReadOnlyList<TodoItem> items)
        {
            return items.Select(i => new TodoItemDto(i.Id, i.Title, i.IsCompleted, i.Order));
        }

        private void ExecuteAndRefresh(Action action)
        {
            try {
                action();
                RefreshList();
            }
            catch (Exception ex) {
                _view.ShowError(ex.Message);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
