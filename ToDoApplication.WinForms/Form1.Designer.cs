namespace ToDoApplication.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbNewTask = new TextBox();
            btnAddTask = new Button();
            lbTasks = new CheckedListBox();
            btnDeleteTask = new Button();
            btnCompletedlTasks = new Button();
            btnUp = new Button();
            btnDown = new Button();
            SuspendLayout();
            // 
            // tbNewTask
            // 
            tbNewTask.Location = new Point(12, 405);
            tbNewTask.Name = "tbNewTask";
            tbNewTask.Size = new Size(583, 23);
            tbNewTask.TabIndex = 0;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(635, 404);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(153, 23);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "Create Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTodoItem_Click;
            // 
            // lbTasks
            // 
            lbTasks.FormattingEnabled = true;
            lbTasks.Location = new Point(12, 12);
            lbTasks.Name = "lbTasks";
            lbTasks.Size = new Size(583, 382);
            lbTasks.TabIndex = 2;
            lbTasks.ItemCheck += lbTasks_ItemCheck;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(635, 12);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(153, 23);
            btnDeleteTask.TabIndex = 3;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTodoItem_Click;
            // 
            // btnCompletedlTasks
            // 
            btnCompletedlTasks.Location = new Point(635, 41);
            btnCompletedlTasks.Name = "btnCompletedlTasks";
            btnCompletedlTasks.Size = new Size(153, 23);
            btnCompletedlTasks.TabIndex = 4;
            btnCompletedlTasks.Text = "Delete Completed Tasks";
            btnCompletedlTasks.UseVisualStyleBackColor = true;
            btnCompletedlTasks.Click += btnDeleteCompletedTasks_Click;
            // 
            // btnUp
            // 
            btnUp.Location = new Point(639, 72);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(70, 50);
            btnUp.TabIndex = 5;
            btnUp.Text = "UP";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Location = new Point(715, 72);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(70, 50);
            btnDown.TabIndex = 6;
            btnDown.Text = "DOWN";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(btnCompletedlTasks);
            Controls.Add(btnDeleteTask);
            Controls.Add(lbTasks);
            Controls.Add(btnAddTask);
            Controls.Add(tbNewTask);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNewTask;
        private Button btnAddTask;
        private CheckedListBox lbTasks;
        private Button btnDeleteTask;
        private Button btnCompletedlTasks;
        private Button btnUp;
        private Button btnDown;
    }
}
