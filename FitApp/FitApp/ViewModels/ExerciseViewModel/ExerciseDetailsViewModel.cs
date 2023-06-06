using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;

namespace FitApp.ViewModels.ExerciseViewModel
{
    public class ExerciseDetailsViewModel : AItemDatailsViewModel<Exercises>
    {
        public ExerciseDetailsViewModel()
            : base()
        {
        }

        #region Fields
        private string name;
        private string description;
        private DateTime createdDate;
        private DateTime modifiedDate;
        #endregion Fields

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public DateTime CreatedDate
        {
            get => createdDate;
            set => SetProperty(ref createdDate, value);
        }
        public DateTime ModifiedDate
        {
            get => modifiedDate;
            set => SetProperty(ref modifiedDate, value);
        }
        #endregion Properties

        public override void LoadProperties(Exercises item)
        {
            Name = item.ExerciseName;
            Description = item.ExerciseDescription;
            CreatedDate = item.CreationDate.DateTime;
            ModifiedDate = item.ModificationDate.DateTime;
        }
    }
}