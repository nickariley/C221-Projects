using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BooksInventory
{
    class BooksContext : DbContext
    {
        public DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            String DatabaseFile = Path.Combine(ProjectBase.FullName, "BookInventory.db");

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);


            
        }
        public void Print()
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"Book ID: {book.Id} Title: {book.Title} Author: {book.Author}");
            }
        }

        public void Print(Books books)
        {
            Console.WriteLine($"Book ID: {books.Id} Title: {books.Title} Author: {books.Author}");
        }
    }
}
