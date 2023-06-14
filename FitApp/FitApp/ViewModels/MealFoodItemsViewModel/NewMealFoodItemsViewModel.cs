using FitApp.Helpers;
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

        private int foodItemiId;
        private FoodItems selectedFoodItem;
        private List<FoodItems> foodItems;
        private int mealId;
        private Meals selectedMeal;
        private List<Meals> meals;
        private string servingSize;
        private string servingsPerMeal;
        private FoodItemService foodItemService;
        private MealsModelService mealsModelService;

        #endregion

        #region Properties

        public FoodItems SelectedFoodItem
        {
            get => selectedFoodItem;
            set 
            { 
                SetProperty(ref selectedFoodItem, value);
                OnPropertyChanged(nameof(SelectedFoodItem));
            }
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
            set 
            { 
                SetProperty(ref selectedMeal, value); 
                OnPropertyChanged(nameof(SelectedMeal));
            }
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
            foodItemService = new FoodItemService();
            mealsModelService = new MealsModelService();

            foodItemService.RefreshListFromService();
            foodItems = foodItemService.items;

            mealsModelService.RefreshListFromService();
            meals = mealsModelService.items;

        }

        #endregion

        #region Methods

        public override MealFoodItems SetItem()
        {
            var item = new MealFoodItems()
            {
                CreationDate = DateTime.Now,
                FoodItemID = this.SelectedFoodItem.FoodItemID,
                IsActive = true,
                MealID = this.SelectedMeal.MealID,
                ModificationDate = DateTime.Now,
                ServingsPerMeal = this.ServingsPerMeal,
                ServingSize = this.ServingSize,
                Title = this.Title,
                Notes = "Taki zywot jest grubasa"
            }.CopyProperties(this);
            return item;
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(ServingSize);
        }

        #endregion

    }
}
