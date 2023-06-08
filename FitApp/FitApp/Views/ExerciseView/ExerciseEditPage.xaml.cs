using FitApp.ViewModels.ExerciseViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.ExerciseView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseEditPage : ContentPage
    {
        public ExerciseEditPage()
        {
            InitializeComponent();
            BindingContext = new ExerciseDetailsViewModel();
        }
    }
}