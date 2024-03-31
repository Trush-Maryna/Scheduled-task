import javax.swing.*;
import java.awt.*;

public class Executor extends JFrame {

    private final Scheduled scheduled;
    private JButton btnStart, btnDelete, btnEdit;
    private JList<Task> listBoxTasks;
    private JTextField txtDescription;
    private DateTimePicker dateTimePicker;

    public Executor() {
        setTitle("Scheduled Task Executor");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(400, 300);
        setLocationRelativeTo(null);

        scheduled = new Scheduled();

        initComponents();
        setupLayout();
        setupListeners();

        scheduled.setUpdateTaskCallback(this::updateTaskInListBox);

        Timer timerTask = new Timer(1000, e -> scheduled.updateReminder());
        timerTask.start();
    }

    private void initComponents() {
        dateTimePicker = new DateTimePicker();
        txtDescription = new JTextField();
        listBoxTasks = new JList<>();
        btnStart = new JButton("Start");
        btnDelete = new JButton("Delete");
        btnEdit = new JButton("Edit");
    }

    private void setupLayout() {
        Container contentPane = getContentPane();
        contentPane.setLayout(new BorderLayout());

        JPanel panelTop = new JPanel(new GridLayout(2, 2));
        panelTop.add(new JLabel("Description:"));
        panelTop.add(txtDescription);
        panelTop.add(new JLabel("Execution Time:"));
        panelTop.add(dateTimePicker);
        contentPane.add(panelTop, BorderLayout.NORTH);

        contentPane.add(new JScrollPane(listBoxTasks), BorderLayout.CENTER);

        JPanel panelBottom = new JPanel(new FlowLayout());
        panelBottom.add(btnStart);
        panelBottom.add(btnDelete);
        panelBottom.add(btnEdit);
        contentPane.add(panelBottom, BorderLayout.SOUTH);
    }

    private void setupListeners() {
        btnStart.addActionListener(e -> {
            String description = txtDescription.getText();
            Task task = new Task(description, dateTimePicker.getValue());
            scheduled.addTask(task);
            listBoxTasks.setListData(scheduled.getTaskList().toArray(new Task[0]));
            JOptionPane.showMessageDialog(null, "Task scheduled successfully!", "Confirmation", JOptionPane.INFORMATION_MESSAGE);
            txtDescription.setText("");
            dateTimePicker.setValueToCurrentTime();
            scheduled.updateReminder();
        });

        btnDelete.addActionListener(e -> {
            if (listBoxTasks.getSelectedValue() != null) {
                Task selectedTask = listBoxTasks.getSelectedValue();
                scheduled.removeTask(selectedTask);
                listBoxTasks.setListData(scheduled.getTaskList().toArray(new Task[0]));
            } else {
                JOptionPane.showMessageDialog(null, "Please select a task to delete.", "Error", JOptionPane.ERROR_MESSAGE);
            }
        });

        btnEdit.addActionListener(e -> {
            Task selectedTask = listBoxTasks.getSelectedValue();
            if (selectedTask != null) {
                int selectedIndex = listBoxTasks.getSelectedIndex();
                Task editedTask = createEditForm(selectedTask, selectedIndex).getEditedTask();
                if (editedTask != null) {
                    scheduled.removeTask(selectedTask);
                    scheduled.addTask(editedTask);
                    listBoxTasks.setListData(scheduled.getTaskList().toArray(new Task[0]));
                    scheduled.updateReminder();
                    dateTimePicker.setValueToCurrentTime();
                }
            } else {
                JOptionPane.showMessageDialog(null, "Please select a task to edit.", "Error", JOptionPane.ERROR_MESSAGE);
            }
        });
    }

    private EditForm createEditForm(Task task, int selectedIndex) {
        EditForm editForm = new EditForm(task, selectedIndex);
        editForm.setVisible(true);
        return editForm;
    }

    private void updateTaskInListBox(Task task, int index) {
        listBoxTasks.setListData(scheduled.getTaskList().toArray(new Task[0]));
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new Executor().setVisible(true));
    }
}