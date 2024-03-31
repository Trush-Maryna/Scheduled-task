import javax.swing.*;
import java.awt.*;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.Date;

class DateTimePicker extends JPanel {
    private final JSpinner dateSpinner;
    private final JSpinner timeSpinner;

    public DateTimePicker() {
        this(LocalDateTime.now());
    }

    public DateTimePicker(LocalDateTime dateTime) {
        setLayout(new GridLayout(1, 2));

        dateSpinner = new JSpinner(new SpinnerDateModel());
        dateSpinner.setEditor(new JSpinner.DateEditor(dateSpinner, "dd.MM.yyyy"));
        dateSpinner.setValue(Date.from(dateTime.atZone(ZoneId.systemDefault()).toInstant()));
        add(dateSpinner);

        timeSpinner = new JSpinner(new SpinnerDateModel());
        JSpinner.DateEditor timeEditor = new JSpinner.DateEditor(timeSpinner, "HH:mm");
        timeSpinner.setEditor(timeEditor);
        timeSpinner.setValue(Date.from(dateTime.atZone(ZoneId.systemDefault()).toInstant()));
        add(timeSpinner);
    }

    public LocalDateTime getValue() {
        Date date = (Date) dateSpinner.getValue();
        Date time = (Date) timeSpinner.getValue();
        LocalDateTime localDateTime = LocalDateTime.ofInstant(date.toInstant(), ZoneId.systemDefault());
        localDateTime = localDateTime.withHour(time.getHours()).withMinute(time.getMinutes());
        return localDateTime;
    }

    public void setValueToCurrentTime() {
        setValue(LocalDateTime.now());
    }

    public void setValue(LocalDateTime dateTime) {
        dateSpinner.setValue(Date.from(dateTime.atZone(ZoneId.systemDefault()).toInstant()));
        timeSpinner.setValue(Date.from(dateTime.atZone(ZoneId.systemDefault()).toInstant()));
    }
}
