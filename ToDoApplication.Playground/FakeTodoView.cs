using ToDoApplication.Presentation.Interfaces;

namespace ToDoApplication.Playground
{
    public class FakeTodoView : ITodoView
    {
        public event Action<string>? AddButtonClicked;

        public void SimulateUserClick(string title)
        {
            AddButtonClicked?.Invoke(title);
        }

        public void DisplayTodoItems(IEnumerable<string> items)
        {
            Console.WriteLine("Updated list:");
            foreach (var item in items)
                Console.WriteLine(item);
        }
    }
}
