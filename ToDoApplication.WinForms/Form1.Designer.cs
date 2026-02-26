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
            SuspendLayout();
            // 
            // tbNewTask
            // 
            tbNewTask.Location = new Point(12, 405);
            tbNewTask.Name = "tbNewTask";
            tbNewTask.Size = new Size(645, 23);
            tbNewTask.TabIndex = 0;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(668, 404);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(120, 23);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "Create Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // lbTasks
            // 
            lbTasks.FormattingEnabled = true;
            lbTasks.Location = new Point(12, 12);
            lbTasks.Name = "lbTasks";
            lbTasks.Size = new Size(645, 382);
            lbTasks.TabIndex = 2;
            lbTasks.ItemCheck += lbTasks_ItemCheck;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
