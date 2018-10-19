using System;
using System.Collections.Generic;

namespace LibAcc.Abstractions
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PrintDate { get; set; }

        public DateTime AccountDate { get; set; }

        public ICollection<BookAttribute> Attributes { get; set; }
    }
}
