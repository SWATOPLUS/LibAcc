using System;
using LibAcc.Abstractions.Models;

namespace LibAcc.Server.Services
{
    public class RentOrderCrudServiceMock : CrudServiceMockBase<RentOrder>
    {
        private static RentOrder[] _dataSet =
        {
            new RentOrder
            {
                RentOrderId = 1,
                BookId = 1,
                OrderDate = DateTime.Now.AddDays(-1),
                CustomerId = 1,
                OrderDays = 30,
            },
            new RentOrder
            {
                RentOrderId = 2,
                BookId = 2,
                OrderDate = DateTime.Now.AddDays(-60),
                CustomerId = 2,
                OrderDays = 30,
            },
            new RentOrder
            {
                RentOrderId = 3,
                BookId = 2,
                OrderDate = DateTime.Now.AddDays(-60),
                CustomerId = 3,
                OrderDays = 30,
                ReturnDate = DateTime.Now.AddDays(-31),
            },
            new RentOrder
            {
                RentOrderId = 4,
                BookId = 3,
                OrderDate = DateTime.Now.AddDays(-1),
                CustomerId = 3,
                OrderDays = 30,
            },
            new RentOrder
            {
                RentOrderId = 5,
                BookId = 3,
                OrderDate = DateTime.Now.AddDays(-200),
                CustomerId = 1,
                OrderDays = 30,
                ReturnDate = DateTime.Now.AddDays(-180),
            },
            new RentOrder
            {
                RentOrderId = 6,
                BookId = 3,
                OrderDate = DateTime.Now.AddDays(-40),
                CustomerId = 2,
                OrderDays = 30,
                ReturnDate = DateTime.Now.AddDays(-10),
            },

        };

        public RentOrderCrudServiceMock() : base(_dataSet)
        {
        }
    }
}
