using FitApp.ViewModels;
using FitApp.Views;
using FitApp.Views.ExerciseView;
using FitApp.Views.FoodItemView;
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
            Routing.RegisterRoute(nameof(ExerciseDetailsPage), typeof(ExerciseDetailsPage));
            Routing.RegisterRoute(nameof(ExerciseEditPage), typeof(ExerciseEditPage));
            Routing.RegisterRoute(nameof(NewFoodItemPage), typeof(NewFoodItemPage));
            Routing.RegisterRoute(nameof(FoodItemDetailsPage), typeof(FoodItemDetailsPage));
            Routing.RegisterRoute(nameof(FoodItemEditPage), typeof(FoodItemEditPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
