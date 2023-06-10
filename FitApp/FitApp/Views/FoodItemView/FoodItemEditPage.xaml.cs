using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.FoodItemView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItemEditPage : ContentPage
    {
        public FoodItemEditPage()
        {
            InitializeComponent();
            BindingContext = new FoodItemEditPage();
        }
    }
}