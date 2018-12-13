using System;

namespace LibAcc.Abstractions.Models
{
    public class RentOrder
    {
        public int RentOrderId { get; set; }

        public int CustomerId { get; set; }

        public int BookId { get; set; }

        public int OrderDays { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}