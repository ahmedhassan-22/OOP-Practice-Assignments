using BookLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projects
{
    class program
    {
      
        static void Main(string[] args)
        {
            Library library = new Library();
           
            while (true)
            {
                Console.WriteLine("\n===== Book Library System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. List All Books");
                Console.WriteLine("5. Search Book");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(library);
                        Fille();
                        break;

                    case "2":
                        BorrowBook(library);
                        break;

                    case "3":
                        ReturnBook(library);
                        break;

                    case "4":
                        ListBooks(library);
                        break;

                    case "5":
                        SearchBooks(library);
                        break;

                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddBook(Library library)
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
                Console.WriteLine("Invalid number of copies.");
                return;
            }

            if (library.AddBook(title, author, isbn, totalCopies))
                Console.WriteLine("Book added successfully.");
            else
                Console.WriteLine("Could not add book. Check the data or ISBN.");
        }

        static void BorrowBook(Library library)
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine() ?? "";

            if (library.BorrowBook(isbn))
                Console.WriteLine("Book borrowed successfully.");
            else
                Console.WriteLine("Book cannot be borrowed. It may not exist or no copies are available.");
        }

        static void ReturnBook(Library library)
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine() ?? "";

            if (library.ReturnBook(isbn))
                Console.WriteLine("Book returned successfully.");
            else
                Console.WriteLine("Book cannot be returned. It may not exist or all copies are already available.");
        }

        static void ListBooks(Library library)
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

        static void SearchBooks(Library library)
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
       public static void Fille()
        {
            FileStream file = new FileStream("test.txt", FileMode.OpenOrCreate);

            File.WriteAllText("test.txt", "Hello");
        }
    }
}