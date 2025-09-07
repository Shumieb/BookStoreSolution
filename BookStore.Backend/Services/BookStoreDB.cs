using BookStore.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStore.Backend.Services
{
    public class BookStoreDb : DbContext
    {
        public BookStoreDb(DbContextOptions<BookStoreDb> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Name = "Lord of the rings", Description = "This is the lord of the rings", Price = 24.99M, AuthorId = 1, CategoryId = 1, ReleaseDate = new DateOnly(2015, 10, 21) },
                new Book { BookId = 2, Name = "Lord of the rings 1", Description = "This is the lord of the rings 1", Price = 4.99M, AuthorId = 1, CategoryId = 1, ReleaseDate = new DateOnly(2022, 08, 21) },
                new Book { BookId = 3, Name = "Harry Potter", Description = "This is harry potter", Price = 8.99M, AuthorId = 2, CategoryId = 2, ReleaseDate = new DateOnly(2003, 02, 01) },
                new Book { BookId = 4, Name = "Harry Potter 2", Description = "This is harry potter 2", Price = 14.99M, AuthorId = 2, CategoryId = 2, ReleaseDate = new DateOnly(1998, 05, 15) }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "R.K. Token", Added = new DateOnly(2025, 09, 14) },
                new Author { AuthorId = 2, Name = "J.K Rowling", Added = new DateOnly(2002, 07, 21) }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Fiction", Description = "This is the fiction description" },
                new Category { CategoryId = 2, Name = "Drama", Description = "This is the drama description" }
             );
        }
    }
}