using System;
using System.Collections.Generic;
using System.Text;

namespace PoCos
{
    class Book
    {
        public string Title { get; private set; }

        public string[] Authors { get; private set; }

        public int Pages { get; private set; }

        public int SKU { get; private set; }

        public string Publisher { get; private set; }

        public double Price { get; private set; }

        public int ReviewStars { get; set; }

        public string ReviewText { get; set; }

        public string Summary { get; set; }


        public Book(string title, string[] authors, int pages, int sku, string publisher, double price)
        {
            Title = title;
            Authors = authors;
            Pages = pages;
            SKU = sku;
            Publisher = publisher;
            Price = price;
        }

        public Book(string title, string[] authors, int pages, int sku, string publisher, double price, int reviewStars, string reviewText, string summary)
        {
            Title = title;
            Authors = authors;
            Pages = pages;
            SKU = sku;
            Publisher = publisher;
            Price = price;
            ReviewStars = reviewStars;
            ReviewText = reviewText;
            Summary = summary;
        }

        public string GetBookWithReview()
        {
            return ($"{this.Title} was written by {this.Authors[0]} {this.Authors[1]} it is {this.Pages} pages long. It was published by {this.Publisher} " +
                $"You can find this book on amazon under SKU# {this.SKU} for around ${this.Price}, plus tax.\nI read this book as a young boy, so I " +
                $"could relate with the main character Billy on many levels. I give this book {this.ReviewStars} stars out of 5 stars, because it's {this.ReviewText}.\n" +
                $"A short summary of the book:\n{this.Summary}");
        }

        public string GetBookWoutReview()
        {
            return ($"{this.Title} was written by {this.Authors[0]} {this.Authors[1]} it is {this.Pages} pages long. It was published by {this.Publisher} " +
                $"You can find this book on amazon under SKU# {this.SKU} for around ${this.Price}, plus tax.\nA short summary of the book:\n{this.Summary}");
        }
    }
}
