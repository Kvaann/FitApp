using FitApp.ViewModels;
using FitApp.Views;
using FitApp.Views.ExerciseView;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FitApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewExercisePage), typeof(NewExercisePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
