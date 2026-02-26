using System.Windows.Forms;
using ToDoApplication.Presentation.Interfaces;
using ToDoApplication.Presentation.Models;

namespace ToDoApplication.WinForms
{
    public partial class Form1 : Form, ITodoView
    {
        public event Action<string>? AddButtonClicked;
        public event Action<int>? ItemToggleedCompleted;

        public Form1()
        {
            InitializeComponent();

            tbNewTask.Focus();
            lbTasks.DisplayMember = "Title";
            lbTasks.ValueMember = "Id";
        }


        public void DisplayTodoItems(IEnumerable<TodoItemDto> items)
        {
            lbTasks.Items.Clear();
            foreach (var item in items) {
                lbTasks.Items.Add(item, item.IsCompleted);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(tbNewTask.Text);
            tbNewTask.Text = string.Empty;
            tbNewTask.Focus();
        }

        private void lbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = (TodoItemDto)lbTasks.Items[e.Index];
            ItemToggleedCompleted?.Invoke(item.Id);
        }
    }
}
