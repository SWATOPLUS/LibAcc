using LibAcc.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace LibAcc.EfRepositories
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookAttribute> BookAttributes { get; set; }
    }
}