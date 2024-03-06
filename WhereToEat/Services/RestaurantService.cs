using System.Diagnostics;
using System.Net.Http.Json;
using WhereToEat.Model;

namespace WhereToEat.Services
{
    public class RestaurantService
    {
        HttpClient httpClient;
        public RestaurantService()
        {
            this.httpClient = new HttpClient();
        }

        List<Restaurant> restaurants;
        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            if (restaurants?.Count > 0)
                return restaurants;

            // Online
            var response = await httpClient.GetAsync("https://gist.githubusercontent.com/Pughgramming/26ff47e01eae46a6ffc18ad589d46da9/raw/a9c1256ba507991a7dad514cfc721f6b9f24e147/restaurants.json");
            if (response.IsSuccessStatusCode)
            {
                restaurants = await response.Content.ReadFromJsonAsync(RestaurantContext.Default.ListRestaurant);
            }

            // Offline
            /*using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            monkeyList = JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);*/

            return restaurants;
        }
    }
}
