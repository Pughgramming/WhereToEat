using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereToEat.Model;
using WhereToEat.Services;

namespace WhereToEat.ViewModel
{
    public partial class RestaurantViewModel : BaseViewModel
    {
        public ObservableCollection<Restaurant> Restaurants { get; } = new();
        RestaurantService restaurantService;
        public RestaurantViewModel(RestaurantService restaurantService)
        {
            Title = "Restaurant Picker";
            this.restaurantService = restaurantService;
        }

        [RelayCommand]
        async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var restaurants = await restaurantService.GetRestaurantsAsync();

                if (Restaurants.Count != 0)
                    Restaurants.Clear();

                foreach (var restaurant in restaurants)
                    Restaurants.Add(restaurant);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
