using BookLibrary;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookLibrary
{

    public class Library
    {
        private readonly List<Book> books = new();

        private void SaveBooks()
        {
            using StreamWriter writer =
                new StreamWriter("Books.txt", false, Encoding.UTF8);

            foreach (Book book in books)
            {
                writer.WriteLine(
                    $"{book.Title},{book.Author},{book.ISBN}," +
                    $"{book.TotalCopies},{book.AvailableCopies}"
                );
            }
        }
        public bool AddBook(string title, string author, string isbn, int totalCopies, int availableCobies)
        {
        
            if (title == null || author == null || isbn == null || totalCopies <= 0 || availableCobies < 0 ||
                availableCobies > totalCopies)
            {
                return false;
            }

            foreach (Book book in books)
            {
               if( book.ISBN.Equals(isbn,StringComparison.OrdinalIgnoreCase))
               {
                    return false;
               }
            } 
            try
            {
                books.Add(new Book(title, author, isbn, totalCopies, availableCobies ));
            }
            catch(Exception M)
            { Console.WriteLine(M.Message); }

            //string bookData = $"{title},{author},{isbn},{totalCopies},{availableCobies}{Environment.NewLine}";
            //byte[] bytes = Encoding.UTF8.GetBytes(bookData);

            //using (FileStream file = new FileStream(
            //    "Books.txt",
            //    FileMode.Append,
            //    FileAccess.Write))
            //{
            //    file.Write(bytes, 0, bytes.Length);
            //}
            SaveBooks();
            return true;

        }

        public bool BorrowBook(string isbn)
        {
            if (isbn == null )
                return false;

            foreach (Book b in books)
            {
                if (b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
                {
                    if ( b.AvailableCopies <= 0)
                        return false;

                    b.AvailableCopies--;
                    SaveBooks();
                    return true;
                }
            }
           
            return false;
        }

        public bool ReturnBook(string isbn)
        {
            if (isbn == null)
                return false;
            foreach(Book book in books)
            {
                if (book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
                    if (book.AvailableCopies >= book.TotalCopies)
                    return false;

                book.AvailableCopies++;
                SaveBooks();
                return true;
            }
           
            return false;
        }

        public List<Book> GetAllBooks()
        {
            if (!File.Exists("Books.txt"))
                return books;

            string[] lines = File.ReadAllLines("Books.txt");

            books.Clear();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split(',');

                if (data.Length != 5)
                    continue;

                string title = data[0];
                string author = data[1];
                string isbn = data[2];

                if (!int.TryParse(data[3], out int totalCopies))
                    continue;

                if (!int.TryParse(data[4], out int availableCobies))
                    continue;
                books.Add(new Book(title, author, isbn, totalCopies, availableCobies));
            }

            return books;
        }
        public List<Book> SearchBooks(string search)
        {
            List<Book> result = new List<Book>();
          
                foreach (Book book in books)
                {
                    if (book.Title.Equals(search,StringComparison.OrdinalIgnoreCase)
                    || book.Author.Equals(search, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(book);
                    }
                }     
                    return result;
        }
    }
}