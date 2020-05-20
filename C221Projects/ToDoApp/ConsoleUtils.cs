using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class ConsoleUtils //handles only input and output
    {
        //static ItemContext context = new ItemContext();

        public int UtilGetUserOption()
        {

            UtilPrintMenu();

            var result = string.Empty;

            result = Console.ReadLine().ToUpper().Trim();

            if (int.TryParse(result, out int number))
            {
                return number;
            }
            else
            {
                return 8;
            }

        }

        public void UtilPrintMenu()
        {
            Console.WriteLine($"\t1: Add a ToDoItem\n\t2: Delete a ToDoItem\n\t3: Mark a ToDoItem as Done\n\t4: List All ToDoItems\n\t5: List all Done ToDoItems\n\t6: List all Pending ToDoItems\n\t7: To Exit the App");
            Console.WriteLine($"\tEnter the option number:");
        }


        public void UtilPrintList(List<ToDoItem> toDoItem)
        {
            Console.Clear();
            foreach (var item in toDoItem)
            {
                Console.WriteLine($"\tToDoItem ID: {item.Id}\n\tToDoItem Pending: {item.Pending}\n\tToDoItem Description: {item.Description}\n\n");
            }

        }

        public int UtilGetItem()
        {
            Console.WriteLine($"Please enter the ID of the ToDoItem you want to work with:");
            string getStringId = Console.ReadLine();
            Int32.TryParse(getStringId, out int getId);
            return getId;

        }

        public string UtilAddItem()
        {
            Console.WriteLine($"Please enter the Description of the ToDoItem:");
            string desc = Console.ReadLine();
            Console.Clear();
            return desc;
        }

        public void UtilError()
        {
            Console.WriteLine($"Bad Input or Item does not exist");
        }
    }
}
