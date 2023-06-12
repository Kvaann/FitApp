using FitApp.ViewModels.UsersViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.UserView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEditPage : ContentPage
    {
        public UserEditPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailsViewModel();
        }
    }
}