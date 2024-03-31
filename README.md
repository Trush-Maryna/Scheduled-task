****
# :star2:  `Scheduled-task`

### :black_nib:	����������� �� ������������ �������
#### **����������� ��������** � ������ ������������, ���� ��������������� � �������� ��������� ���� ��� ����������� ��������� ����������. ������� ��������� ������� �� ���������� ����������� ����.
#### **������������:**
- �������� ���������� �������� **� ���������� ���**, ������������ ��������� ������������ ������� � ���� � ������;
- �������� **��������� ��������** ���������� **���������** �� ��������� �������� �������;
- **������� ������� ������������ ����**, ����� �� ��������� ��������� �����, �������� � �������������� ������� ��� ��������� �� ���������.

### ĳ������ ����� �� �����

##### Class Diagram Scheduled-task:
```mermaid
---
title: Scheduled-task
---
classDiagram
    Executor --> Scheduled
    class Executor{
        - scheduled: Scheduled
        + Executor()
        + UpdateTaskInListBox()
    }
    class Scheduled{
        - taskList: List<Task>
        - UpdateTaskCallback: TaskUpdated?
        + Scheduled()
        + AddTask()
        + GetDueTasks()
        + HasTasks()
        + RemoveTask()
        + UpdateReminder()
    }
    Executor --> Task
    Scheduled --> Task
    class Task{
        - description: string?
        - executionTime: DateTime
        + Task()
        + ToString()
    }
```
##### State Diagram Scheduled-task:
```mermaid
---
title: Scheduled-task
---
stateDiagram
    [*] --> Start
    Start --> AddTask
    Start --> Off
    Start --> Start: timerTask
    Start --> Start: UpdateReminder
    AddTask --> Start
    Start --> EditTask
    EditTask --> AddTask
    DeleteTask --> Start
    Start --> DeleteTask
    Off --> [*]
```
### ���� �������� ����������� �������� :
- **Scheduled** - ����, �� ������� �� ���������� �������. ³� ���� ������ ��� ��������� ������� �� ��������, ���������� ���� �� ��������� �� �������;
- **Task** - ����, �� ����� ������ ��������, ��� ������� ��������. ̳����� ����� �� ���������, �������� ��� ���������;
- **Executor** - ����������.

###### �� ������ ����� ��������� ��������� ��������� �� �������. 

### ������� ����������:
##### - [en.wikipedia.org](https://en.wikipedia.org/wiki/Scheduled-task_pattern)
##### - [subscription.packtpub.com](https://subscription.packtpub.com/book/programming/9781785887130/5/ch05lvl1sec61/scheduled-task-pattern)
##### - [wintercms.com](https://wintercms.com/docs/v1.2/docs/plugin/scheduling)
****