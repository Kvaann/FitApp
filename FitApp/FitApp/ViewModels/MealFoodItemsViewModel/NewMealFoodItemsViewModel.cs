using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;
using System.Collections.Generic;

namespace FitApp.ViewModels.MealFoodItemsViewModel
{
    public class NewMealFoodItemsViewModel : ANewViewModel<MealFoodItems>
    {
        #region Fields

        //private int mealFoodItemId;
        private string foodItemName;
        private FoodItems selectedFoodItem;
        private List<FoodItems> foodItems;
        private string mealName;
        private Meals selectedMeal;
        private List<Meals> meals;
        private string servingSize;
        private string servingsPerMeal;

        #endregion

        #region Properties

        public FoodItems SelectedFoodItem
        {
            get => selectedFoodItem;
            set => SetProperty(ref selectedFoodItem, value);
        }

        public List<FoodItems> FoodItems
        {
            get
            {
                return foodItems;
            }
        }

        public Meals SelectedMeal
        {
            get => selectedMeal;
            set => SetProperty(ref selectedMeal, value);
        }

        public List<Meals> Meals
        {
            get
            {
                return meals;
            }
        }

        public string ServingSize
        {
            get => servingSize;
            set => SetProperty(ref servingSize, value);
        }

        public string ServingsPerMeal
        {
            get => servingsPerMeal;
            set => SetProperty(ref servingsPerMeal, value);
        }

        #endregion

        #region Constructor

        public NewMealFoodItemsViewModel()
            : base()
        {
            selectedFoodItem = new FoodItems();
            selectedMeal = new Meals();

            var foodItemDataStorage = new FoodItemService();
            foodItemDataStorage.RefreshListFromService();
            foodItems = foodItemDataStorage.items;

            var mealDataStorage = new MealsModelService();
            mealDataStorage.RefreshListFromService();
            meals = mealDataStorage.items;

        }

        #endregion

        #region Methods

        public override MealFoodItems SetItem()
        {
            return new MealFoodItems()
            {
                CreationDate = DateTime.Now,
                FoodItem = this.SelectedFoodItem,
                FoodItemID = this.SelectedFoodItem.FoodItemID,
                IsActive = true,
                Meal = this.SelectedMeal,
                MealID = this.SelectedMeal.MealID,
                ModificationDate = DateTime.Now,
                ServingsPerMeal = this.ServingsPerMeal,
                ServingSize = this.ServingSize,
                Title = this.Title,
                Notes = "Taki zywot jest grubasa"
            };
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(servingSize);
        }

        #endregion

    }
}
