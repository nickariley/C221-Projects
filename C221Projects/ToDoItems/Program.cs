using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoItems
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            List<ToDoItem> ToDoList = new List<ToDoItem>();
            ToDoItem newToDoItem;
            do
            {
                
                Console.Clear();
                Console.WriteLine("Please enter a ToDo item description, the due date, and priority of Low, Medium, or High.\n");

                Console.Write("Enter Description:");
                string description = Console.ReadLine().ToUpper();
                
                Console.Write("Enter Due Date:");
                string dueDate = Console.ReadLine().ToUpper();

                Console.Write("Enter Priority Level - High, Medium or Low:");
                string priority = Console.ReadLine().ToUpper();

                newToDoItem = new ToDoItem(description, dueDate, priority);

                ToDoList.Add(newToDoItem);

                
                Console.WriteLine("Would you like to enter another to do item? y/n");
                string userAnswer = Console.ReadLine().ToUpper();

                if (userAnswer.Contains("Y"))
                {
                    continue;
                }

                else if (userAnswer.Contains("N"))
                {
                    break;
                }
            }
            while (playAgain == true);

            //IEnumerable<ToDoItem> listSortedHigh = ToDoList.OrderBy(o => o.Priority == "low").ThenBy(o => o.Priority == "medium").ThenBy(o => o.Priority == "high");

            var highPriorityList = newToDoItem.GetHighPriorityList(ToDoList);

            Console.Clear();
            
            foreach (ToDoItem item in highPriorityList)
            {
                Console.WriteLine($"\t{item.Description}\t{item.DueDate}\t{item.Priority}");
                Console.ReadKey();
            }
        }
    }
}
