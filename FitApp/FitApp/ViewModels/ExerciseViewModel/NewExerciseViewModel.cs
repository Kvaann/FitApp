using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;

namespace FitApp.ViewModels.ExerciseViewModel
{
    public class NewExerciseViewModel : ANewViewModel<Exercises>
    {
        #region Fields

        private int exerciseID;
        private string exerciseName;
        private string exerciseDescription;
        private string exerciseType;
        private string muscleGroup;

        #endregion

        #region Properties

        public int ExerciseID
        {
            get => exerciseID;
            set => SetProperty(ref exerciseID, value);
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

        #endregion

        #region Contructor

        public NewExerciseViewModel() 
            : base()
        {
        }

        #endregion

        #region Methods

        public override bool ValidateSave()
        {
            throw new NotImplementedException();
        }

        public override Exercises SetItem()
        {
            return new Exercises
            {
                CreationDate = DateTime.Now,
                ExerciseDescription = this.ExerciseDescription,
                ExerciseType = this.ExerciseType,
                ExerciseName = this.ExerciseName,
                IsActive = true,
                ModificationDate = DateTime.Now,
                MuscleGroup = this.MuscleGroup,
                Notes = "New item",
                Title = "Exercise"
            }.CopyProperties(this);
        }

        #endregion
    }
}
