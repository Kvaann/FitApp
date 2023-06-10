using FitApp.ViewModels.FoodItemsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.FoodItemView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewFoodItemPage : ContentPage
    {
        public NewFoodItemPage()
        {
            InitializeComponent();
            BindingContext = new NewFoodItemViewModel();
        }
    }
}