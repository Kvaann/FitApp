using FitApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FitApp.ViewModels.MealsViewModel
{
    public class MealsViewModel
    {
        public Command MealsCommand { get; }

        public MealsViewModel()
        {
            MealsCommand = new Command(OnMealsClicked);
        }

        private async void OnMealsClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}

