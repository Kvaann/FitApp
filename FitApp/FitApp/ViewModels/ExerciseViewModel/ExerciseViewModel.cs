using FitApp.ViewModels.Abstract;
using FitApp.Views.ExerciseView;
using FitAppApi;
using Xamarin.Forms;

namespace FitApp.ViewModels.ExerciseViewModel
{
    public class ExerciseViewModel : AListViewModel<Exercises>
    {
        public ExerciseViewModel() 
            : base("Exercise")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewExercisePage));
        }

        public override async void OnItemSelected(Exercises item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailsPage)}?{nameof(ExerciseDetailsViewModel.ItemId)}={item.ExerciseID}");
        }
    }
}
