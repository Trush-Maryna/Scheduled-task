namespace ScheduledTask
{
    public partial class Executor : Form
    {
        private Scheduled scheduled;

        public Executor()
        {
            InitializeComponent();
            scheduled = new Scheduled();
            scheduled.UpdateTaskCallback = UpdateTaskInListBox;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            timerTask.Start();
            timerTask.Interval = 1000;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DateTime executionTime = dateTimePicker.Value;
            if (executionTime < DateTime.Now)
            {
                MessageBox.Show("�� �� ������ ���������� ������ �� ������ ����.", "�������");
                return;
            }

            string description = txtDescription.Text;
            Task task = new Task(description, executionTime);
            scheduled.AddTask(task);
            listBoxTasks.Items.Add(task);
            MessageBox.Show("�������� ����������� ������!", "ϳ�����������");

            dateTimePicker.Value = DateTime.Now;
            txtDescription.Text = "";

            scheduled.UpdateReminder();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)listBoxTasks.SelectedItem;
                scheduled.RemoveTask(selectedTask);
                listBoxTasks.Items.Remove(selectedTask);
                dateTimePicker.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("�������� ������� ������ ��� ���������.", "�������");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)listBoxTasks.SelectedItem;
                int selectedIndex = listBoxTasks.SelectedIndex;
                using (Form editForm = CreateEditForm(selectedTask, selectedIndex))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        scheduled.RemoveTask(selectedTask);
                        listBoxTasks.Items.RemoveAt(selectedIndex);

                        Task updatedTask = selectedTask;
                        scheduled.AddTask(updatedTask);
                        listBoxTasks.Items.Insert(selectedIndex, updatedTask);

                        scheduled.UpdateReminder();
                        dateTimePicker.Value = DateTime.Now;
                    }
                }
            }
            else
            {
                MessageBox.Show("�������� ������� ������ ��� �����������.", "�������");
            }
        }

        public Form CreateEditForm(Task task, int selectedIndex)
        {
            Form editForm = new Form();
            editForm.Text = "����������� ������";
            editForm.StartPosition = FormStartPosition.CenterParent;

            TextBox textBoxDescription = new TextBox
            {
                Text = task.Description,
                Dock = DockStyle.Top,
                Multiline = true,
                Height = 100
            };

            DateTimePicker dateTimePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy HH:mm",
                Value = task.ExecutionTime,
                Dock = DockStyle.Top
            };

            Button btnSave = new Button
            {
                Text = "��������",
                Height = 30,
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom
            };

            editForm.Controls.Add(dateTimePicker);
            editForm.Controls.Add(textBoxDescription);
            editForm.Controls.Add(btnSave);

            btnSave.Click += (s, args) =>
            {
                DateTime newExecutionTime = dateTimePicker.Value;
                if (newExecutionTime < DateTime.Now)
                {
                    MessageBox.Show("�� �� ������ ���������� ������ �� ������ ����.", "�������");
                    return;
                }

                task.Description = textBoxDescription.Text;
                task.ExecutionTime = newExecutionTime;
                UpdateTaskInListBox(task, selectedIndex);
            };

            return editForm;
        }

        private void UpdateTaskInListBox(Task task, int index)
        {
            int listIndex = listBoxTasks.Items.IndexOf(task);
            if (listIndex != -1)
            {
                listBoxTasks.Items[listIndex] = task;
            }
        }

        private void timerTask_Tick(object sender, EventArgs e)
        {
            scheduled.UpdateReminder();
        }
    }
}