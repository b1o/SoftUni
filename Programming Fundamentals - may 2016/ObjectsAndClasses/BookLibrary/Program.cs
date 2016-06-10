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
        public Book(string title, string author, string publisher, DateTime releaseDate, long ISBN, decimal price)
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

        public long ISBN { get; set; }

        public decimal Price { get; set; }

        public static Book Parse(string input)
        {
            string[] tokens = input.Split(' ');
            string title = tokens[0];
            string autroh = tokens[1];
            string publisher = tokens[2];
            DateTime releaseDate = DateTime.ParseExact(tokens[3], "d.M.yyyy", CultureInfo.InvariantCulture);
            long ISBN = long.Parse(tokens[4]);
            decimal price = decimal.Parse(tokens[5], CultureInfo.InvariantCulture);

            return new Book(title, autroh, publisher, releaseDate, ISBN, price);
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

            var result =
                library.Books.GroupBy(t => new {Author = t.Author})
                    .Select(g => new
                    {
                        Average = g.Sum(p => p.Price),
                        Author = g.Key.Author
                    })
                    .ToDictionary(x => x.Author, x => x.Average)
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);

            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:f}");
            }
        }
    }
}
