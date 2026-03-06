using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using ToDoApplication.Application.UseCases;
using ToDoApplication.Presentation.Models;

namespace ToDoApplication.Presentation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CreateTodoItemUseCase _createUC;
        private readonly GetTodoItemsUseCase _getUC;
        private readonly ToggleCompletedUseCase _toggleTodoItemCompletedUC;
        private readonly DeleteTodoItemUseCase _deleteUC;
        private readonly DeleteCompletedUseCase _deleteCompletedUC;
        private readonly SwapItemsOrderUseCase _swapItemsOrderUC;

        public ObservableCollection<TodoItemViewModel> Todos { get; } = new ObservableCollection<TodoItemViewModel>();
        private string newTodoText;
        public string NewTodoText
        {
            get => newTodoText;
            set
            {
                if (newTodoText == value)
                    return;

                newTodoText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewTodoText)));
            }
        }

        private TodoItemViewModel? _selectedTodo; //выделеный элемент в окне
        public TodoItemViewModel? SelectedTodo
        {
            get => _selectedTodo;
            set
            {
                if (_selectedTodo != value) {
                    _selectedTodo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTodo)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public ICommand AddTodoCommand { get; }
        public ICommand DeleteTodoCommand { get; }
        public ICommand ToggleCompletedCommand { get; }
        public ICommand DeleteCompletedCommand { get; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }

        public MainViewModel(
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


            AddTodoCommand = new RelayCommand(AddTodo);
            DeleteTodoCommand = new RelayCommand<TodoItemViewModel>(DeleteTodo);
            ToggleCompletedCommand = new RelayCommand<TodoItemViewModel>(ToggleCompletedTodo);
            DeleteCompletedCommand = new RelayCommand(DeleteCompletedTodo);
            MoveUpCommand = new RelayCommand<TodoItemViewModel>(MoveUp, t => t != null);
            MoveDownCommand = new RelayCommand<TodoItemViewModel>(MoveDown, t => t != null);

            LoadTodoItems();
        }

        private void LoadTodoItems()
        {
            var selectedId = SelectedTodo?.Id;

            var items = _getUC.Execute();
            
            Todos.Clear();
            foreach (var item in items) {
                Todos.Add(new TodoItemViewModel(item.Id, item.Title, item.Order, item.IsCompleted));
            }

            if (selectedId != null)
                SelectedTodo = Todos.FirstOrDefault(t => t.Id == selectedId);
        }

        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoText)) {
                _createUC.Execute(NewTodoText);
                NewTodoText = "";
                LoadTodoItems();
            }
        }

        private void DeleteTodo(TodoItemViewModel todo)
        {
            if (todo == null) return;

            _deleteUC.Execute(todo.Id);
            LoadTodoItems();
        }

        private void ToggleCompletedTodo(TodoItemViewModel todo)
        {
            if (todo == null) return;
            _toggleTodoItemCompletedUC.Execute(todo.Id);
            LoadTodoItems();
        }

        private void DeleteCompletedTodo()
        {
            _deleteCompletedUC.Execute();
            LoadTodoItems();
        }

        private void MoveUp(TodoItemViewModel todo)
        {
            var todoIndex = Todos.IndexOf(todo);
            if (todoIndex <= 0) return;

            var otherTodo = Todos[todoIndex - 1];

            _swapItemsOrderUC.Execute(todo.Id, otherTodo.Id);
            LoadTodoItems();
        }

        private void MoveDown(TodoItemViewModel todo)
        {
            var todoIndex = Todos.IndexOf(todo);
            if (todoIndex >= Todos.Count - 1) return;

            var otherTodo = Todos[todoIndex + 1];

            _swapItemsOrderUC.Execute(todo.Id, otherTodo.Id);
            LoadTodoItems();
        }
    }
}
