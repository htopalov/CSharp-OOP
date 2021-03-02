using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {

        private string title;
        private string author;
        private decimal price;

        public Book(string author,string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title 
        {
            get { return title; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }
        public string Author 
        {
            get { return author; }
            private set
            {
                string[] authorNames = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (char.IsDigit(authorNames[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            }
        }
        public virtual decimal Price 
        {
            get { return price; }
            set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Author: {this.Author}");
            sb.AppendLine($"Price: {this.Price:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
