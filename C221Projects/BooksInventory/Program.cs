using System;

namespace BooksInventory
{
    class Program
    {
        static BooksContext context = new BooksContext();
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            bool entering = true;

            while (entering)
            {
                Console.Clear();
                Console.WriteLine($"Please enter an option between 1-5:\n1: To Add a Book\n2: To Update a Book\n3: To Remove a Book\n4: To see Book inventory List:\n5: To see a single Book:");

                try
                {
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    if (userInput < 1 || userInput > 5)
                    {
                        Console.WriteLine($"Invalid selection, please choose between 1-5");
                    }
                    else
                    {
                        switch (userInput)
                        {

                            case 1:
                                if (entering)
                                {
                                    Console.Clear();
                                    context.Print();
                                    Console.WriteLine("Enter the Title:");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter the Author:");
                                    string author = Console.ReadLine();
                                    Books book = new Books(title, author);
                                    context.Add(book);

                                    context.SaveChanges();
                                    Console.Clear();

                                }
                                break;


                            case 2:
                                Console.Clear();
                                Console.WriteLine("Please enter the ID of the Book you would like to update:");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the new Title of the book you wish to update");
                                string updateTitle = Console.ReadLine();
                                Console.WriteLine("Enter the new Author of the book you wish to update");
                                string updateAuthor = Console.ReadLine();
                                var updatingBook = GetBook(id);
                                updatingBook.Title = updateTitle;
                                updatingBook.Author = updateAuthor;
                                context.Update(updatingBook);

                                context.SaveChanges();
                                Console.Clear();

                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("Please enter the ID of the Book you wish to Remove:");
                                int removeID = Convert.ToInt32(Console.ReadLine());
                                var removingBook = GetBook(removeID);
                                context.Remove(removingBook);

                                context.SaveChanges();

                                Console.Clear();

                                break;

                            case 4:
                                Console.Clear();

                                Console.WriteLine("Here's a list of books in the inventory");

                                context.Print();

                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("Please enter the ID of the Book you wish to read:");
                                int singleBookId = Convert.ToInt32(Console.ReadLine());

                                context.Print(GetBook(singleBookId));

                                break;
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"You entered invalid data: {ex.Message}");
                    Console.WriteLine($"{ex.StackTrace}");
                }

                Console.WriteLine("Would you like to Add, Update or Remove any more Books? Y/N:");

                string endLoop = Console.ReadLine().ToUpper();
                if (endLoop == "Y")
                {
                    continue;
                }
                else if (endLoop == "N")
                {
                    entering = false;
                }
            }

            Console.ReadKey();
        }

        public static Books GetBook(int id)
        {
            return context.Books.Find(id);
        }

    }
}
