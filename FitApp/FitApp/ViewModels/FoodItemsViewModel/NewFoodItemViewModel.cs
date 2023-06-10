using FitApp.Helpers;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;

namespace FitApp.ViewModels.FoodItemsViewModel
{
    public class NewFoodItemViewModel : ANewViewModel<FoodItems>
    {
        #region Fields

        private int foodItemID;
        private string foodItemName;
        private string foodItemDescription;
        private string foodItemCalories;

        #endregion

        #region Properties

        public int FoodItemID
        {
            get => foodItemID;
            set => SetProperty(ref foodItemID, value);
        }

        public string FoodItemName
        {
            get => foodItemName;
            set => SetProperty(ref foodItemName, value);
        }

        public string FoodItemDescription
        {
            get => foodItemDescription;
            set => SetProperty(ref foodItemDescription, value);
        }

        public string FoodItemCalories
        {
            get => foodItemCalories;
            set => SetProperty(ref foodItemCalories, value);
        }


        #endregion

        #region Contructor

        public NewFoodItemViewModel()
            : base()
        {
        }

        #endregion

        #region Methods

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(foodItemName);
        }

        public override FoodItems SetItem()
        {
            return new FoodItems
            {
                CreationDate = DateTime.Now,
                FoodItemID = this.FoodItemID,
                FoodItemName = this.FoodItemName,
                FoodItemDescription = this.FoodItemDescription,
                IsActive = true,
                ModificationDate = DateTime.Now,
                Notes = "New item",
                Title = "Exercise"
            }.CopyProperties(this);
        }

        #endregion
    }
}
