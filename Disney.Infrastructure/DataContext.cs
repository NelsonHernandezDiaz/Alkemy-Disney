using Disney.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<MovieSerie> MoviesSeries {get;set;}
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
