using System;
using LibAcc.Abstractions.Models;

namespace LibAcc.Server.Services
{
    public class BookCrudServiceMock : CrudServiceMockBase<Book>
    {
        private static Book[] _dataSet =
        {
            new Book
            {
                BookId = 1,
                AccountDate = DateTime.Now.AddDays(-454),
                Title = "Poems vol. 1",
                Author = "Alexander Pushkin",
                PrintDate = new DateTime(2010, 1, 1),
            },
            new Book
            {
                BookId = 2,
                AccountDate = DateTime.Now.AddDays(-420),
                Title = "Java for students",
                Author = "Vadim Sakovich",
                PrintDate = new DateTime(2015, 1, 1),
            },
            new Book
            {
                BookId = 3,
                AccountDate = DateTime.Now.AddDays(-392),
                Title = "The world best file managers",
                Author = "Vyacheslav Ryabi",
                PrintDate = new DateTime(2017, 1, 1),
                Description = "Limited edition"
            },

        };

        public BookCrudServiceMock() : base(_dataSet)
        {
        }
    }
}
