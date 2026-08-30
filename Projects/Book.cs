using System;
using System.Collections.Generic;
using System.Text;


namespace BookLibrary
{
    public class Book
    {
        
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies  { get; set; }

        public Book(string title, string author, string isbn, int totalCopies ,int availableCobies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            TotalCopies = totalCopies;
            AvailableCopies = availableCobies;
        }

        public string AvailabilityStatus()
        {
            
                if (AvailableCopies == 0)
                    return "Not Available";
          
            return $"{AvailableCopies} copy/copies available";

        }

    }
}
