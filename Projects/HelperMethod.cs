using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary
{
     public class Methods
     {
        public static void AddBook(Library library)
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? "";

            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine() ?? "";

            Console.Write("Enter total copies: ");

            if (!int.TryParse(Console.ReadLine(), out int totalCopies))
            {
                Console.WriteLine("Invalid number of totalCopies.");
                return;
            }
            Console.Write("Enter available  cobies: ");
            if (!int.TryParse(Console.ReadLine(), out int availableCobies))
            {
                Console.WriteLine("Invalid number of availableCobies.");
                return;
            }

            if (library.AddBook(title, author, isbn, totalCopies , availableCobies))
                Console.WriteLine("Book added successfully.");
            else
                Console.WriteLine("Could not add book. Check the data or ISBN.");
        }

        public static void BorrowBook(Library library)
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine() ?? "";
            
            if (library.BorrowBook(isbn))
                Console.WriteLine("Book borrowed successfully.");
            else
                Console.WriteLine("Book cannot be borrowed. It may not exist or no copies are available.");
        }


        public static void ReturnBook(Library library)
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine() ?? "";

            if (library.ReturnBook(isbn))
                Console.WriteLine("Book returned successfully.");
            else
                Console.WriteLine("Book cannot be returned. It may not exist or all copies are already available.");
        }

        public static void ListBooks(Library library)
        {
            List<Book> books = library.GetAllBooks();

            if (books.Count == 0)

            {
                Console.WriteLine("No books in the library.");
                return;
            }

            Console.WriteLine("\n===== All Books =====");

            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"Total Copies: {book.TotalCopies}");
                Console.WriteLine($"Available Copies: {book.AvailableCopies}");
                Console.WriteLine($"Status: {book.AvailabilityStatus()}");
                Console.WriteLine("---------------------------");
            }
        }

       public static void SearchBooks(Library library)
        {
            Console.Write("Enter title or author to search: ");
            string searchTerm = Console.ReadLine() ?? "";

            List<Book> results = library.SearchBooks(searchTerm);

            if (results.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            Console.WriteLine("\n===== Search Results =====");

            foreach (Book book in results)
            {
                Console.WriteLine(
                    $"{book.Title} | {book.Author} | ISBN: {book.ISBN} | " +
                    $"Available: {book.AvailableCopies}/{book.TotalCopies}");
            }
        }
       
    }
}
