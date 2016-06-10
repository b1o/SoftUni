using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Book
    {
        public Book(string title, string author, string publisher, DateTime releaseDate, string ISBN, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = ISBN;
            this.Price = price;
        }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public static Book Parse(string input)
        {
            string[] tokens = input.Split(' ');
            string title = tokens[0];
            string author = tokens[1];
            string publisher = tokens[2];
            DateTime releaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            string ISBN = tokens[4];
            decimal price = decimal.Parse(tokens[5], CultureInfo.InvariantCulture);

            return new Book(title, author, publisher, releaseDate, ISBN, price);
        }
    }

    class Library
    {
        public Library(string name)
        {
            this.Name = name;
            this.Books = new List<Book>();
        }

        public Library(string name, List<Book> books) : this(name)
        {
            this.Books = books;
        }

        public List<Book> Books { get; set; }

        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Library");

            int booksCount = int.Parse(Console.ReadLine());


            for (int i = 0; i < booksCount; i++)
            {
                library.Books.Add(Book.Parse(Console.ReadLine()));
            }

            DateTime desiredDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var result = library.Books.Where(b => b.ReleaseDate > desiredDate)
                .OrderBy(b => b.ReleaseDate)
                .ThenBy(b => b.Author);

            foreach (var book in result)
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
            }
        }
    }
}

