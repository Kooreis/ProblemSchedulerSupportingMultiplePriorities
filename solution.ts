Here is a simple console application in TypeScript that creates a scheduler with support for multiple priorities for task execution. This application uses a priority queue to manage tasks.

```typescript
class Task {
    constructor(public priority: number, public task: () => void) {}
}

class PriorityQueue {
    private tasks: Task[] = [];

    enqueue(task: Task) {
        if (this.isEmpty()) {
            this.tasks.push(task);
        } else {
            let added = false;
            for (let i = 0; i < this.tasks.length; i++) {
                if (task.priority > this.tasks[i].priority) {
                    this.tasks.splice(i, 0, task);
                    added = true;
                    break;
                }
            }
            if (!added) {
                this.tasks.push(task);
            }
        }
    }

    dequeue() {
        return this.tasks.shift();
    }

    isEmpty() {
        return this.tasks.length === 0;
    }
}

class Scheduler {
    private taskQueue = new PriorityQueue();

    scheduleTask(priority: number, task: () => void) {
        this.taskQueue.enqueue(new Task(priority, task));
    }

    executeTasks() {
        while (!this.taskQueue.isEmpty()) {
            const task = this.taskQueue.dequeue();
            task.task();
        }
    }
}

const scheduler = new Scheduler();

scheduler.scheduleTask(1, () => console.log('Executing task with priority 1'));
scheduler.scheduleTask(3, () => console.log('Executing task with priority 3'));
scheduler.scheduleTask(2, () => console.log('Executing task with priority 2'));

scheduler.executeTasks();
```

In this application, the `Task` class represents a task with a priority and a function to execute. The `PriorityQueue` class is a simple implementation of a priority queue, where tasks with higher priority are dequeued before tasks with lower priority. The `Scheduler` class uses a `PriorityQueue` to manage tasks and provides methods to schedule and execute tasks.