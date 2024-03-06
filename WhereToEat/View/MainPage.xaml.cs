using WhereToEat.ViewModel;

namespace WhereToEat
{
    public partial class MainPage : ContentPage
    {
        public MainPage(RestaurantViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
