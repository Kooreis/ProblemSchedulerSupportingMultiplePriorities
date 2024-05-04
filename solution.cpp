```cpp
#include <iostream>
#include <queue>
#include <functional>

class Task {
public:
    virtual void execute() = 0;
};

class TaskA : public Task {
public:
    void execute() override {
        std::cout << "Executing Task A" << std::endl;
    }
};

class TaskB : public Task {
public:
    void execute() override {
        std::cout << "Executing Task B" << std::endl;
    }
};

class Scheduler {
private:
    std::priority_queue<std::pair<int, Task*>> taskQueue;
public:
    void addTask(int priority, Task* task) {
        taskQueue.push(std::make_pair(priority, task));
    }

    void executeTasks() {
        while (!taskQueue.empty()) {
            Task* task = taskQueue.top().second;
            task->execute();
            taskQueue.pop();
        }
    }
};

int main() {
    Scheduler scheduler;
    TaskA taskA;
    TaskB taskB;

    scheduler.addTask(2, &taskA);
    scheduler.addTask(1, &taskB);

    scheduler.executeTasks();

    return 0;
}
```