using FitApp.ViewModels.Abstract;
using FitApp.Views.ExerciseView;
using FitAppApi;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using FitApp.Services.Abstract;

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
            await Shell.Current.GoToAsync(nameof(ExercisePage));
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
