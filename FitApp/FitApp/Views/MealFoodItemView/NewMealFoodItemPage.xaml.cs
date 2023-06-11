using FitApp.ViewModels.MealFoodItemsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.MealFoodItemView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMealFoodItemPage : ContentPage
    {
        public NewMealFoodItemPage()
        {
            InitializeComponent();
            BindingContext = new NewMealFoodItemsViewModel();
        }
    }
}