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
    }
}