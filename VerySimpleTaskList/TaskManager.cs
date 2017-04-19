using System;
using System.Collections.Generic;

namespace VerySimpleTaskList
{
    public class TaskManager
    {
        public TaskManager()
        {
            _tasks = new List<Task>();
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                int choice = GetNumberFromUser();

                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    DoAddTask();
                }
                else if (choice == 2)
                {
                    DoMarkTaskComplete();
                }
                else if (choice == 3)
                {
                    DoSetPriority();
                }
                else if (choice == 4)
                {
                    DoListAllTasks();
                }
                else if (choice == 5)
                {
                    DoRemoveTask();
                }
            }
        }

        private void DoListAllTasks()
        {
            Console.Clear();
            Console.WriteLine("YOUR TASKS");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        private void DoSetPriority()
        {
            Console.Clear();
            Console.WriteLine("CHANGE TASK PRIORITY");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("What task do you want to change? ");

            int index = GetNumberFromUser();

            Console.Write("What is the new task's priority? ");

            int newPriority = GetValidIndexFromUser();

            _tasks[index].SetPriority(newPriority);
        }

        private void DoMarkTaskComplete()
        {
            Console.Clear();
            Console.WriteLine("COMPLETE A TASK");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("What task did you complete? ");

            int index = GetValidIndexFromUser();
            _tasks[index].MarkCompleted();
        }

        private void DoRemoveTask()
        {
            Console.Clear();
            Console.WriteLine("REMOVE A TASK");
            Console.WriteLine("-------------------------");
            PrintNumberedTaskList();
            Console.WriteLine("-------------------------");
            Console.Write("What task would you like to remove? ");

            int index = GetValidIndexFromUser();
            if (index >= 0 && index < _tasks.Count)
            {
                _tasks.RemoveAt(index);

            }

        }

        private void PrintNumberedTaskList()
        {
            for (int i = 0; i < _tasks.Count; i += 1)
            {
                Task task = _tasks[i];
                Console.WriteLine($"{i}. {task.DescribeYourself()}");
            }
        }

        private void DoAddTask()
        {
            Console.Clear();
            Console.WriteLine("ADD A TASK");
            Console.WriteLine("-------------------------");
            Console.WriteLine("What is your next task?");

            string description = GetStringFromUser();

            Console.WriteLine("Would you like to add a reminder, Yes or No?");
            string userresponse = GetStringFromUser();

            if (userresponse == "Yes")
            {
                Console.WriteLine("In how may hours should I remind you?");
                string answer = GetStringFromUser();
                int numberofHours = int.Parse(answer);
                //int numberofHours = int.Parse(GetStringFromUser());

                ReminderTask newTask = new ReminderTask(description, numberofHours);
                _tasks.Add(newTask);

            }

            else
            {
                Task newTask = new Task(description);
                _tasks.Add(newTask);

            }





        }

        private string GetStringFromUser()
        {
            return Console.ReadLine();
        }

        private int GetNumberFromUser()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        private int GetValidIndexFromUser()

        {
            while (true)
            {
                string index = Console.ReadLine();
                int validindex = int.Parse(index);

                if (validindex >= 0 && validindex < _tasks.Count)
                {
                    return validindex;
                }

                else Console.WriteLine("Sorry, that index is invalid.");
            }

        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("TASK MANAGEMENT!");
            Console.WriteLine("You have " + _tasks.Count + " tasks");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Mark a task complete");
            Console.WriteLine("3. Set a task's priority");
            Console.WriteLine("4. List the tasks");
            Console.WriteLine("5. Remove a task");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            Console.WriteLine("-------------------------");
            Console.Write("What would you like to do? ");
        }

        private List<Task> _tasks;
    }
}
