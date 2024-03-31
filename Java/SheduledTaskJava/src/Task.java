import java.time.LocalDateTime;

class Task {
    private String description;
    private LocalDateTime executionTime;

    public Task(String description, LocalDateTime executionTime) {
        this.description = description;
        this.executionTime = executionTime;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public LocalDateTime getExecutionTime() {
        return executionTime;
    }

    public void setExecutionTime(LocalDateTime executionTime) {
        this.executionTime = executionTime;
    }

    @Override
    public String toString() {
        return description + " - " + executionTime.toString();
    }
}
