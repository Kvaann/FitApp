using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.FoodItemView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItemDetailsPage : ContentPage
    {
        public FoodItemDetailsPage()
        {
            InitializeComponent();
            BindingContext = new FoodItemDetailsPage();
        }
    }
}