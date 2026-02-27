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

            ExecuteSafe(() => _createUseCase.Execute(title));
            RefreshList();
        }

        private void OnDeleteButtonClicked(int id)
        {
            ExecuteSafe(() => _deleteUseCase.Execute(id));
            RefreshList();
        }

        private void OnDeleteCompletedClicked()
        {
            ExecuteSafe(() => _deleteCompletedUseCase.Execute());
            RefreshList();
        }

        private void OnItemToggledCompleted(int id)
        {
            ExecuteSafe(() => _toggleCompletedUseCase.Execute(id));
            RefreshList();
        }

        private void OnSwapButtonClicked(int id1, int id2)
        {
            ExecuteSafe(() => _swapOrderUseCase.Execute(id1, id2));
            RefreshList();
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

        private void ExecuteSafe(Action action)
        {
            try {
                action();
            }
            catch (Exception ex) {
                _view.ShowError(ex.Message);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
