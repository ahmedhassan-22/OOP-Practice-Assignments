using BookLibrary;
using System;
using System.Collections.Generic;

using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BookLibrary
{
    class program
    {

        static void Main(string[] args)
        {

            //string filePath = "test.txt";
            //List<string> catalog = new List<string>();
            //try
            //{
            //    if (File.Exists(filePath))
            //    {
            //        catalog = File.ReadAllLines(filePath).ToList();
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("An error while reading the file.");
            //}

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
                        Methods.AddBook(library);

                        break;

                    case "2":
                        Methods.BorrowBook(library);
                        break;

                    case "3":
                        Methods.ReturnBook(library);
                        break;

                    case "4":
                        Methods.ListBooks(library);
                        break;

                    case "5":
                        Methods.SearchBooks(library);
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