using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<StoreBooks> StoreBooks { get; set; }
        public DbSet<Stores> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreBooks>()
                .HasKey(c => new { c.BookId, c.StoreId });

            modelBuilder.Entity<StoreBooks>()
                .HasOne(bc => bc.Books)
                .WithMany(b => b.StoreBooks)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<StoreBooks>()
                .HasOne(bc => bc.Stores)
                .WithMany(c => c.StoreBooks)
                .HasForeignKey(bc => bc.StoreId);


        }
    }
}