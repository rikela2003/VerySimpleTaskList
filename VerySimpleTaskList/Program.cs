using System;

namespace VerySimpleTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WelcomeToWhatEverYouWant");
            TaskManager manager = new TaskManager();
            manager.Run();
        }
    }
}
