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