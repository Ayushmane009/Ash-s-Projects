def add_task(task):
    with open("tasks.txt", "a") as file:
        file.write(task + "\n")

def view_tasks():
    try:
        with open("tasks.txt", "r") as file:
            tasks = file.readlines()
            if tasks:
                for index, task in enumerate(tasks, start=1):
                    print(f"{index}. {task.strip()}")
            else:
                print("No tasks found!")
    except FileNotFoundError:
        print("No tasks found!")

def main():
    while True:
        print("\nTo-Do List")
        print("1. Add Task\n2. View Tasks\n3. Exit")
        choice = input("Choose an option: ")

        if choice == "1":
            task = input("Enter task: ")
            add_task(task)
        elif choice == "2":
            view_tasks()
        elif choice == "3":
            print("Exiting...")
            break
        else:
            print("Invalid choice! Try again.")

if __name__ == "__main__":
    main()