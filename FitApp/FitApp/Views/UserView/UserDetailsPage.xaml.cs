using FitApp.ViewModels.UsersViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.UserView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        public UserDetailsPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailsViewModel();
        }
    }
}