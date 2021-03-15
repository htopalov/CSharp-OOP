using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Books_Before
{
    public class Library
    {
        private List<Book> books;

        public Library(List<Book> books)
        {
            this.books = books;
        }

        public string TurnPage(Book book, int page)
        {
            if (books.Contains(book))
            {
                book.Location = page;
            }
            return $"Current page for {book.Title} is : {book.Location}";
        }
    }
}
