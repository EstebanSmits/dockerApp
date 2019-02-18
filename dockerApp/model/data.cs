using Microsoft.EntityFrameworkCore;

namespace dockerApp.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
            });

            #region SeedBook
            modelBuilder.Entity<Book>().HasData(
                new Book {Id= 1, Title = "Grapes of Wrath", Author="John Steinbeck"},
                new Book {Id= 2, Title = "Hitchhikers Guide to the Galaxy", Author="Douglas Adams"}
                );
            #endregion
        }
    }

}