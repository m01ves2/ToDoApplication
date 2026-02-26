using ToDoApplication.Presentation;

namespace ToDoApplication.Playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var view = new FakeTodoView();
            var presenter = new TodoPresenter(view);

            view.SimulateUserClick("Task 1");
            view.SimulateUserClick("Task 2");
        }
    }
}