#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

void addTask(const string& task) {
    ofstream file("tasks.txt", ios::app);
    if (file.is_open()) {
        file << task << endl;
        file.close();
    } else {
        cout << "Error opening file!" << endl;
    }
}

void viewTasks() {
    ifstream file("tasks.txt");
    string task;
    int count = 1;

    if (file.is_open()) {
        while (getline(file, task)) {
            cout << count++ << ". " << task << endl;
        }
        file.close();
    } else {
        cout << "No tasks found!" << endl;
    }
}

int main() {
    int choice;
    string task;

    while (true) {
        cout << "\nTo-Do List\n";
        cout << "1. Add Task\n2. View Tasks\n3. Exit\nChoose an option: ";
        cin >> choice;
        cin.ignore();

        switch (choice) {
            case 1:
                cout << "Enter task: ";
                getline(cin, task);
                addTask(task);
                break;
            case 2:
                viewTasks();
                break;
            case 3:
                cout << "Exiting...\n";
                return 0;
            default:
                cout << "Invalid choice! Try again.\n";
        }
    }
}