using FitApp.ViewModels.UsersViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.UserView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private UserViewModel _viewModel;
        public UserPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UserViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}