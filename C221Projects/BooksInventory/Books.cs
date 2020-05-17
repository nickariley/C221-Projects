namespace BooksInventory
{
    class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Id { get; set; }

        public Books(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }

    }
}
