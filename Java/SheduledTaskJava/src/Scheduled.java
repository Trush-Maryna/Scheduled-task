import javax.swing.*;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

class Scheduled {
    private final List<Task> taskList;

    public Scheduled() {
        taskList = new ArrayList<>();
    }

    public void addTask(Task task) {
        taskList.add(task);
    }

    public List<Task> getDueTasks() {
        List<Task> dueTasks = new ArrayList<>();
        LocalDateTime now = LocalDateTime.now();
        for (Task task : taskList) {
            if (task.getExecutionTime().isBefore(now)) {
                dueTasks.add(task);
            }
        }
        taskList.removeAll(dueTasks);
        return dueTasks;
    }

    public boolean hasTasks() {
        return !taskList.isEmpty();
    }

    public void removeTask(Task task) {
        taskList.remove(task);
    }

    public void updateReminder() {
        List<Task> dueTasks = getDueTasks();
        for (Task task : dueTasks) {
            JOptionPane.showMessageDialog(null, task.getDescription(), "Reminder", JOptionPane.INFORMATION_MESSAGE);
        }
    }

    public List<Task> getTaskList() {
        return taskList;
    }

    public void setUpdateTaskCallback(TaskUpdated callback) {
    }

    public interface TaskUpdated {
        void updateTask(Task task, int index);
    }
}