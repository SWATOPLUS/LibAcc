using System;

namespace LibAcc.Abstractions.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime PrintDate { get; set; }

        public DateTime AccountDate { get; set; }
    }
}
