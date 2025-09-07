using BookStore.Backend.Models;
using BookStore.Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookStoreDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDb")));

var app = builder.Build();

// book routes
RouteGroupBuilder books = app.MapGroup("/books");
books.MapGet("/", GetAllBooks);
books.MapGet("/{id}", GetBook);
books.MapPost("/", CreateBook);
books.MapPut("/{id}", UpdateBook);
books.MapDelete("/{id}", DeleteBook);

// author routes
RouteGroupBuilder authors = app.MapGroup("/authors");
authors.MapGet("/", GetAllAuthors);
authors.MapGet("/{id}", GetAuthor);

// categories routes
RouteGroupBuilder categories = app.MapGroup("/categories");
categories.MapGet("/", GetAllCategories);
categories.MapGet("/{id}", GetCategory);

app.Run();

// get all books
static async Task<IResult> GetAllBooks(BookStoreDb db)
{
    return TypedResults.Ok(
        await db.Books
        .Include(x => x.Author)
        .Include(x => x.Category)
        .ToArrayAsync());
}

// get book by ID
static async Task<IResult> GetBook(int id, BookStoreDb db)
{
    var book = await db.Books
        .Include(x => x.Author)
        .Include(x => x.Category)
        .FirstOrDefaultAsync(x => x.BookId == id);

    return book is not null
        ? TypedResults.Ok(book)
        : TypedResults.NotFound();
}

// create a book
static async Task<IResult> CreateBook(Book book, BookStoreDb db)
{
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/books/{book.BookId}", book);
}

// update a book
static async Task<IResult> UpdateBook(int id, Book book, BookStoreDb db)
{

    var foundBook = await db.Books.FindAsync(id);

    if (foundBook is null) return TypedResults.NotFound();

    foundBook.Name = book.Name;
    foundBook.Description = book.Description;
    foundBook.AuthorId = book.AuthorId;
    foundBook.CategoryId = book.CategoryId;
    foundBook.Price = book.Price;
    foundBook.ReleaseDate = book.ReleaseDate;

    await db.SaveChangesAsync();
    return TypedResults.Ok(foundBook);
}

// delete a book
static async Task<IResult> DeleteBook(int id, BookStoreDb db)
{
    if (await db.Books.FindAsync(id) is Book book)
    {
        db.Books.Remove(book);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    return TypedResults.NoContent();
}

// get all authors
static async Task<IResult> GetAllAuthors(BookStoreDb db)
{
    return TypedResults.Ok(
        await db.Authors
        .ToArrayAsync());
}

// get author by id
static async Task<IResult> GetAuthor(int id, BookStoreDb db)
{
    var author = await db.Authors.FindAsync(id);

    return author is not null
        ? TypedResults.Ok(author)
        : TypedResults.NotFound();
}

// get all categories
static async Task<IResult> GetAllCategories(BookStoreDb db)
{
    return TypedResults.Ok(
        await db.Categories
        .ToArrayAsync());
}

// get category by id
static async Task<IResult> GetCategory(int id, BookStoreDb db)
{
    var category = await db.Categories.FindAsync(id);

    return category is not null
        ? TypedResults.Ok(category)
        : TypedResults.NotFound();
}
