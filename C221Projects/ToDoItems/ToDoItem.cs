using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToDoItems
{
    class ToDoItem
    {
        public string Description { get; set; }

        public string DueDate { get; set; }

        public string Priority { get; set; }

        public ToDoItem(string description, string dueDate, string priority)
        {
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }

        public IEnumerable<ToDoItem> GetHighPriorityList(List<ToDoItem> ToDoList)
        {
            IEnumerable < ToDoItem > listSortedHigh = ToDoList.OrderBy(o => o.Priority == "LOW").ThenBy(o => o.Priority == "MEDIUM").ThenBy(o => o.Priority == "HIGH");

            return listSortedHigh;

            
        }


    }
}
