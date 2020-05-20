using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class ToDoItem //model to match up to columns in database
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Pending { get; set; }


        public ToDoItem()
        {
            this.Description = "";
            this.Pending = true;
        }
    }
}
