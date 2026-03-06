using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private readonly DeleteTodoItemUseCase _deleteTodoItemUC;
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

        public ICommand AddTodoCommand { get; }
        //public ICommand DeleteTodoCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel(
            GetTodoItemsUseCase getUC,
            CreateTodoItemUseCase createUC,
            ToggleCompletedUseCase ToggleTodoItemCompletedUC,
            DeleteTodoItemUseCase deleteTodoItemUC,
            DeleteCompletedUseCase deleteCompletedUC,
            SwapItemsOrderUseCase swapItemsOrderUC)
        {
            _createUC = createUC;
            _getUC = getUC;
            _toggleTodoItemCompletedUC = ToggleTodoItemCompletedUC;
            _deleteTodoItemUC = deleteTodoItemUC;
            _deleteCompletedUC = deleteCompletedUC;
            _swapItemsOrderUC = swapItemsOrderUC;


            AddTodoCommand = new RelayCommand(AddTodo);
            //DeleteTodoCommand = new RelayCommand(DeleteTodo);
            LoadTodoItems();
        }


        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoText)) {
                _createUC.Execute(NewTodoText);
                NewTodoText = "";
                LoadTodoItems();
            }
        }

        private void LoadTodoItems()
        {
            var items = _getUC.Execute();
            
            Todos.Clear();
            foreach (var item in items) {
                Todos.Add(new TodoItemViewModel(item.Id, item.Title, item.Order, item.IsCompleted));
            }
        }
    }
}
