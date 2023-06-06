using FitApp.ViewModels.ExerciseViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.ExerciseView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        private ExerciseViewModel _viewModel;
        public ExercisePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ExerciseViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}