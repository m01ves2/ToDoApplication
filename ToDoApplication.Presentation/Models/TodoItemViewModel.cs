using System.ComponentModel;

namespace ToDoApplication.Presentation.Models
{
    public class TodoItemViewModel : INotifyPropertyChanged
    {
        private bool _isCompleted;
        public int Id { get; }
        public string Title { get; }
        public int Order { get; }
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value) {
                    _isCompleted = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public TodoItemViewModel(int id, string title, int order, bool isCompleted)
        {
            Id = id;
            Title = title;
            Order = order;
            IsCompleted = isCompleted;
        }
    }
}
