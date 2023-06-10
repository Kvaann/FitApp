using FitApp.ViewModels.ExerciseViewModel;
using FitApp.ViewModels.FoodItemsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.FoodItemView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItemPage : ContentPage
    {
        private FoodItemsViewModel _viewModel;
        public FoodItemPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FoodItemsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}