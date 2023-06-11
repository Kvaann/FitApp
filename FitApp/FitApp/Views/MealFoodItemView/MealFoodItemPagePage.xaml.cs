using FitApp.ViewModels.MealFoodItemsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.MealFoodItemView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealFoodItemPagePage : ContentPage
    {
        private MealFoodItemsViewModel _viewModel;
        public MealFoodItemPagePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MealFoodItemsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}