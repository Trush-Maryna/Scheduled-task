namespace ScheduledTask
{
    partial class Executor
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
            if (disposing && (components != null))
            {
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
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            dateTimePicker = new DateTimePicker();
            txtDescription = new TextBox();
            listBoxTasks = new ListBox();
            btnEdit = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            timerTask = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(128, 255, 128);
            btnStart.Dock = DockStyle.Top;
            btnStart.FlatAppearance.BorderColor = Color.Green;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Tw Cen MT Condensed", 13.8F, FontStyle.Bold);
            btnStart.Location = new Point(0, 0);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(800, 40);
            btnStart.TabIndex = 0;
            btnStart.Text = "Створити замітку";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "";
            dateTimePicker.Dock = DockStyle.Top;
            dateTimePicker.Location = new Point(0, 99);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(800, 27);
            dateTimePicker.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Top;
            txtDescription.Location = new Point(0, 40);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(800, 59);
            txtDescription.TabIndex = 2;
            // 
            // listBoxTasks
            // 
            listBoxTasks.Dock = DockStyle.Bottom;
            listBoxTasks.FormattingEnabled = true;
            listBoxTasks.Location = new Point(0, 206);
            listBoxTasks.Name = "listBoxTasks";
            listBoxTasks.Size = new Size(800, 244);
            listBoxTasks.TabIndex = 3;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.YellowGreen;
            btnEdit.Dock = DockStyle.Bottom;
            btnEdit.FlatAppearance.BorderColor = Color.Green;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Tw Cen MT Condensed", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(0, 166);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(800, 40);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Редагувати замітку";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LimeGreen;
            btnDelete.Dock = DockStyle.Bottom;
            btnDelete.FlatAppearance.BorderColor = Color.Green;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Tw Cen MT Condensed", 13.8F, FontStyle.Bold);
            btnDelete.Location = new Point(0, 126);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(800, 40);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Видалити замітку";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTimePicker);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(listBoxTasks);
            panel1.Controls.Add(btnStart);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 6;
            // 
            // timerTask
            // 
            timerTask.Tick += timerTask_Tick;
            // 
            // Executor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Executor";
            Text = "Creating Tasks";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private DateTimePicker dateTimePicker;
        private TextBox txtDescription;
        private ListBox listBoxTasks;
        private Button btnEdit;
        private Button btnDelete;
        private Panel panel1;
        private System.Windows.Forms.Timer timerTask;
    }
}
