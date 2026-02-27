using System.Windows.Forms;
using ToDoApplication.Presentation.Interfaces;
using ToDoApplication.Presentation.Models;

namespace ToDoApplication.WinForms
{
    public partial class Form1 : Form, ITodoView
    {
        public event Action<string>? AddButtonClicked;
        public event Action<int>? DeleteButtonClicked;
        public event Action DeleteCompletedButtonClicked;
        public event Action<int>? ItemToggleedCompleted;
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
            tbNewTask.Text = string.Empty;
            tbNewTask.Focus();
        }

        private void lbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isUpdating)
                return;

            var item = (TodoItemDto)lbTasks.Items[e.Index];
            ItemToggleedCompleted?.Invoke(item.Id);
        }

        private void btnDeleteTodoItem_Click(object sender, EventArgs e)
        {
            var selectedItem = (TodoItemDto)lbTasks.SelectedItem;

            if (selectedItem != null) {
                DeleteButtonClicked?.Invoke(selectedItem.Id);
            }
        }

        private void btnDeleteCompletedTasks_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all completed tasks?", "Delete completed tasks", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                DeleteCompletedButtonClicked?.Invoke();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var selectedItem = (TodoItemDto)lbTasks.SelectedItem;
            if (selectedItem == null)
                return;

            int selectedIndex = lbTasks.SelectedIndex;
            if (selectedIndex == 0)
                return;

            var swapWithItem = (TodoItemDto)lbTasks.Items[selectedIndex - 1];
            SwapButtonUpClicked?.Invoke(selectedItem.Id, swapWithItem.Id);

            lbTasks.SelectedIndex = selectedIndex - 1;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var selectedItem = (TodoItemDto)lbTasks.SelectedItem;
            if (selectedItem == null) 
                return;

            int selectedIndex = lbTasks.SelectedIndex;
            if (selectedIndex == lbTasks.Items.Count - 1)
                return;

            var swapWithItem = (TodoItemDto)lbTasks.Items[selectedIndex + 1];
            SwapButtonDownClicked?.Invoke(selectedItem.Id, swapWithItem.Id);

            lbTasks.SelectedIndex = selectedIndex + 1;
        }
    }
}
