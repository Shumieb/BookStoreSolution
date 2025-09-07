using BookStore.FrontEnd.Models;

namespace BookStore.FrontEnd.Clients
{
    public class BooksClient(HttpClient httpClient)
    {
        public async Task<Book[]> GetBooksAsync()
           => await httpClient.GetFromJsonAsync<Book[]>("books") ?? [];

        public async Task AddBookAsync(Book book)
            => await httpClient.PostAsJsonAsync("books", book);

        public async Task<Book> GetBookAsync(int id)
            => await httpClient.GetFromJsonAsync<Book>($"books/{id}")
                ?? throw new Exception("Could not find the book");

        public async Task UpdateBookAsync(Book updatedBook)
            => await httpClient.PutAsJsonAsync($"books/{updatedBook.BookId}", updatedBook);

        public async Task DeleteBookAsync(int id)
        => await httpClient.DeleteAsync($"books/{id}");
    }
}
