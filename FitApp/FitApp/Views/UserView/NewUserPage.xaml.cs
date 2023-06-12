using FitApp.ViewModels.UsersViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.UserView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserPage : ContentPage
    {
        public NewUserPage()
        {
            InitializeComponent();
            BindingContext = new NewUserViewModel();
        }
    }
}