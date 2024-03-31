import javax.swing.*;
import java.awt.*;

class EditForm extends JFrame {
    private final Task editedTask;
    private JTextField txtDescription;
    private DateTimePicker dateTimePicker;
    private JButton btnSave;

    public EditForm(Task task, int selectedIndex) {
        setTitle("Edit Task");
        setSize(300, 200);
        setLocationRelativeTo(null);

        editedTask = new Task(task.getDescription(), task.getExecutionTime());

        initComponents(task);

        Container contentPane = getContentPane();
        contentPane.setLayout(new BorderLayout());

        JPanel panelCenter = new JPanel(new GridLayout(2, 2));
        panelCenter.add(new JLabel("Description:"));
        panelCenter.add(txtDescription);
        panelCenter.add(new JLabel("Execution Time:"));
        panelCenter.add(dateTimePicker);
        contentPane.add(panelCenter, BorderLayout.CENTER);

        btnSave.addActionListener(e -> {
            editedTask.setDescription(txtDescription.getText());
            editedTask.setExecutionTime(dateTimePicker.getValue());
            dispose();
        });

        JPanel panelBottom = new JPanel(new FlowLayout());
        panelBottom.add(btnSave);
        contentPane.add(panelBottom, BorderLayout.SOUTH);
    }

    private void initComponents(Task task) {
        txtDescription = new JTextField(task.getDescription());
        dateTimePicker = new DateTimePicker(task.getExecutionTime());
        btnSave = new JButton("Save");
    }

    public Task getEditedTask() {
        return editedTask;
    }
}