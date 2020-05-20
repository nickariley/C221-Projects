using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace ToDoApp
{
    public class ItemContext : DbContext //houses the entity framework
    {
        public DbSet<ToDoItem> ToDoItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            String DatabaseFile = Path.Combine(ProjectBase.FullName, "ToDoItem.db");

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);

        }
    }
}
