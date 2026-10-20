using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", Pages = 310, IsRead = true },
                new Book { Id = 2, Title = "Harry Potter", Author = "J.K. Rowling", Pages = 320, IsRead = true },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 180, IsRead = false },
                new Book { Id = 4, Title = "1984", Author = "George Orwell", Pages = 328, IsRead = false },
                new Book { Id = 5, Title = "Animal Farm", Author = "George Orwell", Pages = 112, IsRead = true },
                new Book { Id = 6, Title = "The Alchemist", Author = "Paulo Coelho", Pages = 208, IsRead = false }
            );
        }
    }
}