namespace P02._Books_Before
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book() { Title = "Lord of the rings", Author = "Author1"},
                new Book() { Title = "Under the bridge", Author = "Author2"},
                new Book() { Title = "Paranormal", Author = "Author3"},
                new Book() { Title = "Mockingbird", Author = "Author4"},

            };

            Library library = new Library(books);
            Console.WriteLine(library.TurnPage(books[1], 12));
            Console.WriteLine(library.TurnPage(books[0], 2));
        }
    }
}
