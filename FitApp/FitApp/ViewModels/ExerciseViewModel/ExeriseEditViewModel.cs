using FitApp.ViewModels.Abstract;
using FitAppApi;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FitApp.ViewModels.ExerciseViewModel
{
    public class ExeriseEditViewModel : AItemDatailsViewModel<Exercises>
    {
        #region Fields

        private int id;
        private string exerciseName;
        private string exerciseDescription;
        private string exerciseType;
        private string muscleGroup;

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string ExerciseName
        {
            get => exerciseName;
            set => SetProperty(ref exerciseName, value);
        }

        public string ExerciseDescription
        {
            get => exerciseDescription;
            set => SetProperty(ref exerciseDescription, value);
        }

        public string ExerciseType
        {
            get => exerciseType;
            set => SetProperty(ref exerciseType, value);
        }

        public string MuscleGroup
        {
            get => muscleGroup;
            set => SetProperty(ref muscleGroup, value);
        }

        public ObservableCollection<Exercises> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion Properties


        public override void LoadProperties(Exercises item)
        {
            throw new System.NotImplementedException();
        }

    }
}
