using FitApp.ViewModels.MealFoodItemsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.MealFoodItemView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealFoodItemEditPage : ContentPage
    {
        public MealFoodItemEditPage()
        {
            InitializeComponent();
            BindingContext = new MealFoodItemsDetailsViewModel();
        }
    }
}