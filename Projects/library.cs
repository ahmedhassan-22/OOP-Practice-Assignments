using Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary
{

    public class Library
    {
        private readonly List<Book> books = new();
        public bool AddBook(string title, string author, string isbn, int totalCopies)
        {
            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(isbn) ||
                totalCopies <= 0)
            {
                return false;
            }

            if (books.Any(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            books.Add(new Book(title, author, isbn, totalCopies));
            return true;
        }

        public bool BorrowBook(string isbn)
        {
            Book? book = books.FirstOrDefault(
                b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));

            if (book == null || book.AvailableCopies <= 0)
                return false;

            book.AvailableCopies--;
            return true;
        }

        public bool ReturnBook(string isbn)
        {
            Book? book = books.FirstOrDefault(
                b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));

            if (book == null || book.AvailableCopies >= book.TotalCopies)
                return false;

            book.AvailableCopies++;
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public List<Book> SearchBooks(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return new List<Book>();

            return books.Where(b =>
                b.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(search, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}