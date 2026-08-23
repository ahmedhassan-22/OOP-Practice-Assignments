using System;
using System.Collections.Generic;
using System.Text;

namespace Projects
{
    class Book
    {
        private int _totalCopies;

        public string Title { get; set; }
        public string Other { get; set; }
        public int Isbn { get; set; }
       
        public int TotalCobies
        {
            set
            { _totalCopies = value; }
            get 
            { return _totalCopies; }
        }
        public Book(string title , string other,int isbn,int copies )
        {
            if (copies < 0)
                throw new ArgumentException("Copies cannot be negative.");

            Title = title;
            Other = other;
            Isbn = isbn;
            TotalCobies = copies;
        }
        public bool Borrow()
        {
            if()
        }

    }    
}
