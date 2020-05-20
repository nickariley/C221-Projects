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
            Console.WriteLine($"1: Add a ToDoItem\n2: Delete a ToDoItem\n3: Mark a ToDoItem as Done\n4: List All ToDoItems\n5: List all Done ToDoItems\n6: List all Pending ToDoItems\n7: To Exit the App");
            Console.WriteLine($"Enter the option number:");
        }


        public void UtilPrintList(List<ToDoItem> toDoItem)
        {
            Console.Clear();
            foreach (var item in toDoItem)
            {
                Console.WriteLine($"ToDoItem ID: {item.Id}\nToDoItem Description: {item.Description}\n ToDoItem Pending: {item.Pending}");
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
            return desc;
        }

        public void UtilError()
        {
            Console.WriteLine($"Bad Input or Item does not exist");
        }
    }
}
