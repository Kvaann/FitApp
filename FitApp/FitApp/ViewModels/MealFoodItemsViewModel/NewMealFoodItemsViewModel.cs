using FitApp.Helpers;
using FitApp.Services;
using FitApp.Services.Abstract;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Xamarin.Forms;

namespace FitApp.ViewModels.MealFoodItemsViewModel
{
    public class NewMealFoodItemsViewModel : ANewViewModel<MealFoodItems>
    {
        #region Fields

        private int foodItemiId;
        private FoodItems selectedFoodItem;
        private List<FoodItems> foodItems;
        private int mealId;
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

        public int FoodItemiId
        {
            get => foodItemiId;
            set => SetProperty(ref foodItemiId, value);
        }

        public int MealId
        {
            get => mealId;
            set => SetProperty(ref mealId, value);
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
            var item = new MealFoodItems()
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
            return item;
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(ServingSize);
        }

        #endregion

    }
}
