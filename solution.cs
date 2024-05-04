Here is a simple console application in JavaScript that creates a scheduler supporting multiple priorities for task execution. This application uses a priority queue to manage tasks.

```javascript
class Task {
    constructor(priority, name) {
        this.priority = priority;
        this.name = name;
    }
}

class PriorityQueue {
    constructor() {
        this.tasks = [];
    }

    enqueue(priority, name) {
        let task = new Task(priority, name);
        if (this.isEmpty()) {
            this.tasks.push(task);
        } else {
            let added = false;
            for (let i = 0; i < this.tasks.length; i++) {
                if (task.priority < this.tasks[i].priority) {
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
        let value = this.tasks.shift();
        return value;
    }

    isEmpty() {
        return this.tasks.length == 0;
    }
}

let priorityQueue = new PriorityQueue();
priorityQueue.enqueue(3, 'Task 1');
priorityQueue.enqueue(1, 'Task 2');
priorityQueue.enqueue(2, 'Task 3');

while (!priorityQueue.isEmpty()) {
    let task = priorityQueue.dequeue();
    console.log(`Executing task ${task.name} with priority ${task.priority}`);
}
```

This application creates a priority queue and adds tasks to it with different priorities. The tasks are then executed in order of their priority, with the task of highest priority (lowest number) being executed first.