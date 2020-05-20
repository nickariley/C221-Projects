using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoApp
{
    

    public class ItemRepository //this class manages items, ie: add delete pull sort filter
    {
        public ItemContext itemContext = new ItemContext();

        public ItemRepository()
        {
            itemContext.Database.EnsureCreated();
        }

        public void AddItem(string item)
        {
            ToDoItem toDoItem = new ToDoItem();
            toDoItem.Description = item;
            itemContext.ToDoItem.Add(toDoItem);
            itemContext.SaveChanges();
        }

        public void RemoveItem(int id)
        {
            ToDoItem deleteItem = itemContext.ToDoItem.Where(x => x.Id == id).FirstOrDefault();

            if (deleteItem != null)
            {
                itemContext.Remove(deleteItem);
                itemContext.SaveChanges();
            }
            
            // Create an if else statement to check if the number given is a valid ID of a TODO item, if not null remove if null do nothing.
            
        }

        public List<ToDoItem> GetAllItem()
        {
            List<ToDoItem> list = new List<ToDoItem>();

            list = itemContext.ToDoItem.ToList();

            return list;

        }

        public List<ToDoItem> GetDoneItem()
        {
            List<ToDoItem> list = new List<ToDoItem>();

            list = itemContext.ToDoItem.Where(x => x.Pending == false).ToList();

            return list;
        }

        public List<ToDoItem> GetPendingItem()
        {
            List<ToDoItem> list = new List<ToDoItem>();

            list = itemContext.ToDoItem.Where(x => x.Pending == true).ToList();

            return list;
        }

        public void MarkDoneItem(int id)
        {
            ToDoItem markingItem = itemContext.ToDoItem.Where(x => x.Id == id).FirstOrDefault();

            markingItem.Pending = markingItem.Pending == true ? false : true;

            itemContext.Update(markingItem);
            itemContext.SaveChanges();

        }

        public bool CheckItem(int id)
        {
            ToDoItem checkItem = itemContext.ToDoItem.Where(x => x.Id == id).FirstOrDefault();
            if (checkItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
