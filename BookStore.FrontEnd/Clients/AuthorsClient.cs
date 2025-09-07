using BookStore.FrontEnd.Models;

namespace BookStore.FrontEnd.Clients
{
    public class AuthorsClient(HttpClient httpClient)
    {
        public async Task<Author[]> GetAuthorsAsync()
           => await httpClient.GetFromJsonAsync<Author[]>("authors") ?? [];

    }
}
