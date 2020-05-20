using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class App //driver 
    {
        
        ConsoleUtils consoleUtils;
        ItemRepository itemRepository;

        public App()
        {
            consoleUtils = new ConsoleUtils();
            itemRepository = new ItemRepository();
            
        }

        public void Start()
        {
            
            bool isRunning = true;

            while(isRunning)
            {
                var response = consoleUtils.UtilGetUserOption();
                switch (response)
                {

                    case 1:
                        itemRepository.AddItem(consoleUtils.UtilAddItem());
                        break;

                    case 2:
                        if (itemRepository.CheckItem(consoleUtils.UtilGetItem()) == true)
                        {
                            itemRepository.RemoveItem(consoleUtils.UtilGetItem());
                        }
                        else
                        {
                            consoleUtils.UtilError();
                        }
                        
                        break;

                    case 3: // Mark a ToDoItem as Done

                        if (itemRepository.CheckItem(consoleUtils.UtilGetItem()) == true)
                        {
                            itemRepository.MarkDoneItem(consoleUtils.UtilGetItem());
                        }
                        else
                        {
                            consoleUtils.UtilError();
                        }
                        break;

                    case 4: //List all ToDoItems
                        consoleUtils.UtilPrintList(itemRepository.GetAllItem());
                        break;

                    case 5: //List all Done ToDoItems
                        consoleUtils.UtilPrintList(itemRepository.GetDoneItem());
                        break;

                    case 6: //List all Pending ToDoItems
                        consoleUtils.UtilPrintList(itemRepository.GetPendingItem());
                        break;

                    case 7:
                        isRunning = false;
                        break;

                    case 8:
                        consoleUtils.UtilError();
                        break;
                }
            }
            
        }
    }
}
