using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitApp.ViewModels.ExerciseViewModel
{
    public class NewExerciseViewModel : AListViewModel<Exercises>
    {
        public NewExerciseViewModel(string title) : base(title)
        {
        }

        public override void GoToAddPageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
