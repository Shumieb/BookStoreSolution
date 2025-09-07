using BookStore.FrontEnd.Models;

namespace BookStore.FrontEnd.Clients
{
    public class CategoriesClient(HttpClient httpClient)
    {
        public async Task<Category[]> GetCategoriesAsync()
           => await httpClient.GetFromJsonAsync<Category[]>("categories") ?? [];
    }
}
