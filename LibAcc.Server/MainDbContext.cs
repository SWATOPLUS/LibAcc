using LibAcc.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace LibAcc.Server
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<RentOrder> RentOrders { get; set; }
    }
}