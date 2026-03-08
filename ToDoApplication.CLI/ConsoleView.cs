using System.Numerics;
using ToDoApplication.Presentation.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoApplication.CLI
{
    public class ConsoleView
    {
        public event Action<string>? AddTodoRequested;
        public event Action<int>? DeleteTodoRequested;
        public event Action<int>? ToggleCompletedRequested;
        public event Action? DeleteCompleted;
        public event Action<int>? MoveUpRequested;
        public event Action<int>? MoveDownRequested;

        private IReadOnlyList<TodoItemDTO> _todos = new List<TodoItemDTO>();

        // Метод, который VM вызывает при изменении коллекции
        public void Render(IReadOnlyList<TodoItemDTO> todos)
        {
            _todos = todos;
            Console.Clear();

            // --- Header ---
            Console.WriteLine("=== TODO LIST ===");
            Console.WriteLine();

            // --- Body ---
            if (_todos.Count == 0) {
                Console.WriteLine("No items.");
            }
            else {
                for (int i = 0; i < _todos.Count; i++) {
                    var t = _todos[i];
                    Console.WriteLine($"{i + 1}. [{(t.IsCompleted ? "X" : " ")}] {t.Title} (Id: {t.Id})");
                }
            }

            Console.WriteLine();
            // --- Controls ---
            Console.WriteLine("Commands:");
            Console.WriteLine("A - Add todo");
            Console.WriteLine("D - Delete todo by Id");
            Console.WriteLine("C - Delete completed todo");
            Console.WriteLine("T - Toggle completed by Id");
            Console.WriteLine("W - Move up by order number");
            Console.WriteLine("S - Move down by order number");
            Console.WriteLine("Q - Quit");
            Console.WriteLine();
        }

        public void ShowError(string message)
        {
            var consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message); // например, красным цветом
            Console.ForegroundColor = consoleColor;
        }

        // Цикл обработки ввода пользователя
        public void Run()
        {
            while (true) {
                Console.Write("Enter command: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    break;

                InputHandler(input);
            }
        }

        private void InputHandler(string input)
        {
            switch (input.ToUpper()) {
                case "A":
                    Console.Write("Enter todo title: ");
                    string? title = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(title))
                        AddTodoRequested?.Invoke(title);
                    break;

                case "D":
                    Console.Write("Enter Id to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int delId))
                        DeleteTodoRequested?.Invoke(delId);
                    break;

                case "C":
                    DeleteCompleted?.Invoke();
                    break;

                case "T":
                    Console.Write("Enter Id to toggle: ");
                    if (int.TryParse(Console.ReadLine(), out int toggleId))
                        ToggleCompletedRequested?.Invoke(toggleId);
                    break;

                case "W":
                    Console.Write("Enter todo number to move up: ");
                    if (!int.TryParse(Console.ReadLine(), out int numberUp)) {
                        Console.WriteLine("Please enter a valid number.");
                        return;
                    }
                    if (numberUp < 1 || numberUp > _todos.Count) {
                        Console.WriteLine("Number out of range.");
                        return;
                    }

                    if (numberUp == 1) return;
                    var idUp = _todos[numberUp - 1].Id;
                    MoveUpRequested?.Invoke(idUp);
                    break;

                case "S":
                    Console.Write("Enter todo number to move down: ");
                    if (!int.TryParse(Console.ReadLine(), out int numberDown)) {
                        Console.WriteLine("Please enter a valid number.");
                        return;
                    }
                    if (numberDown < 1 || numberDown > _todos.Count) {
                        Console.WriteLine("Number out of range.");
                        return;
                    }

                    if (numberDown == _todos.Count - 1) return;
                    var idDown = _todos[numberDown - 1].Id;
                    MoveDownRequested?.Invoke(idDown);
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
