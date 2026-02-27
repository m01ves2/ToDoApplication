using System.Windows.Forms;
using ToDoApplication.Presentation.Interfaces;
using ToDoApplication.Presentation.Models;

namespace ToDoApplication.WinForms
{
    public partial class Form1 : Form, ITodoView
    {
        public event Action<string>? AddButtonClicked;
        public event Action<int>? DeleteButtonClicked;
        public event Action? DeleteCompletedButtonClicked;
        public event Action<int>? ItemToggledCompleted;
        public event Action<int, int>? SwapButtonUpClicked;
        public event Action<int, int>? SwapButtonDownClicked;

        private bool _isUpdating;
        public Form1()
        {
            InitializeComponent();
            tbNewTask.Focus();
            lbTasks.DisplayMember = "Title";
            lbTasks.ValueMember = "Id";
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DisplayTodoItems(IEnumerable<TodoItemDto> items)
        {
            _isUpdating = true;

            lbTasks.Items.Clear();
            foreach (var item in items) {
                lbTasks.Items.Add(item, item.IsCompleted);
            }

            _isUpdating = false;
        }

        private void btnAddTodoItem_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(tbNewTask.Text);
            tbNewTask.Clear();
            tbNewTask.Focus();
        }

        private void lbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isUpdating)
                return;

            var item = (TodoItemDto)lbTasks.Items[e.Index];
            ItemToggledCompleted?.Invoke(item.Id);
        }

        private void btnDeleteTodoItem_Click(object sender, EventArgs e)
        {
            if (lbTasks.SelectedItem is TodoItemDto selected) //not null
                DeleteButtonClicked?.Invoke(selected.Id);
        }


        private void btnDeleteCompletedTasks_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all completed tasks?", "Delete completed tasks", 
                                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                DeleteCompletedButtonClicked?.Invoke();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lbTasks.SelectedItem is not TodoItemDto selected) return; // проверка на null
            int index = lbTasks.SelectedIndex;
            if (index <= 0) return;

            var swapWith = (TodoItemDto)lbTasks.Items[index - 1];
            SwapButtonUpClicked?.Invoke(selected.Id, swapWith.Id);
            lbTasks.SelectedIndex = index - 1;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lbTasks.SelectedItem is not TodoItemDto selected) return; // проверка на null
            int index = lbTasks.SelectedIndex;
            if (index >= lbTasks.Items.Count - 1) return;

            var swapWith = (TodoItemDto)lbTasks.Items[index + 1];
            SwapButtonDownClicked?.Invoke(selected.Id, swapWith.Id);
            lbTasks.SelectedIndex = index + 1;
        }
    }
}
