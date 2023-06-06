using FitApp.ViewModels.ExerciseViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.ExerciseView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailsPage : ContentPage
    {
        public ExerciseDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ExerciseDetailsViewModel();
        }
    }
}