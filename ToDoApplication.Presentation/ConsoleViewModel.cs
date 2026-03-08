using ToDoApplication.Application.UseCases;
using ToDoApplication.Domain.Exceptions;
using ToDoApplication.Presentation.Models;

namespace ToDoApplication.Presentation
{
    public class ConsoleViewModel
    {
        private readonly CreateTodoItemUseCase _createUC;
        private readonly GetTodoItemsUseCase _getUC;
        private readonly ToggleCompletedUseCase _toggleTodoItemCompletedUC;
        private readonly DeleteTodoItemUseCase _deleteUC;
        private readonly DeleteCompletedUseCase _deleteCompletedUC;
        private readonly SwapItemsOrderUseCase _swapItemsOrderUC;

        private List<TodoItemDTO> _todos  = new List<TodoItemDTO>();
        public event Action<List<TodoItemDTO>>? TodosChanged;
        public event Action<string>? ErrorOccurred;

        public ConsoleViewModel(
            GetTodoItemsUseCase getUC,
            CreateTodoItemUseCase createUC,
            ToggleCompletedUseCase ToggleTodoItemCompletedUC,
            DeleteTodoItemUseCase deleteUC,
            DeleteCompletedUseCase deleteCompletedUC,
            SwapItemsOrderUseCase swapItemsOrderUC)
        {
            _createUC = createUC;
            _getUC = getUC;
            _toggleTodoItemCompletedUC = ToggleTodoItemCompletedUC;
            _deleteUC = deleteUC;
            _deleteCompletedUC = deleteCompletedUC;
            _swapItemsOrderUC = swapItemsOrderUC;
        }

        public void Initialize()
        {
            LoadTodoItems();
        }

        private void LoadTodoItems()
        {
            _todos.Clear();
            var items = _getUC.Execute().Select(t => new TodoItemDTO(t.Id, t.Title, t.Order, t.IsCompleted)).ToList();
            _todos.AddRange(items);
            TodosChanged?.Invoke(_todos);
        }

        public void AddTodo(string NewTodoText)
        {
            if (!string.IsNullOrWhiteSpace(NewTodoText)) {
                _createUC.Execute(NewTodoText);
                NewTodoText = "";
                LoadTodoItems();
            }
        }

        public void DeleteTodo(int id)
        {
            try {
                _deleteUC.Execute(id);
                LoadTodoItems();
            }
            catch (TodoNotFoundException ex) {
                // уведомляем подписчиков (ConsoleView)
                ErrorOccurred?.Invoke($"Error: {ex.Message}");
            }
        }

        public void ToggleCompletedTodo(int id)
        {
            _toggleTodoItemCompletedUC.Execute(id);
            LoadTodoItems();
        }

        public void DeleteCompleted()
        {
            _deleteCompletedUC.Execute();
            LoadTodoItems();
        }

        public void MoveUp(int id)
        {
            var todo = _todos.Where(t => t.Id == id).FirstOrDefault();
            if (todo == null) return;

            int todoIndex = _todos.IndexOf(todo);
            if (todoIndex <= 0) return;

            var otherTodo = _todos[todoIndex - 1];

            _swapItemsOrderUC.Execute(todo.Id, otherTodo.Id);
            LoadTodoItems();
        }

        public void MoveDown(int order)
        {
            var todo = _todos.Where(t => t.Order == order).FirstOrDefault();
            if (todo == null) return;

            int todoIndex = _todos.IndexOf(todo);
            if (todoIndex >= _todos.Count - 1) return;

            var otherTodo = _todos[todoIndex + 1];

            _swapItemsOrderUC.Execute(todo.Id, otherTodo.Id);
            LoadTodoItems();
        }
    }
}
