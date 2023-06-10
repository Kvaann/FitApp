﻿using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.MealFoodItemView;
using FitAppApi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.MealFoodItemsViewModel
{
    public class MealFoodItemsDetailsViewModel : AItemDatailsViewModel<MealFoodItems>
    {
        #region Fields

        private int mealFoodItemId;
        private string selectedFoodItemName;
        private string selectedMealName;
        private string servingSize;
        private string servingsPerMeal;

        #endregion

        #region Properties

        public int MealFoodItemId
        {
            get => mealFoodItemId;
            set => SetProperty(ref mealFoodItemId, value);
        }

        public string SelectedFoodItemName
        {
            get => selectedFoodItemName;
            set => SetProperty(ref selectedFoodItemName, value);
        }

        public string SelectedMealName
        {
            get => selectedMealName;
            set => SetProperty(ref selectedMealName, value);
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

        public ObservableCollection<MealFoodItems> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion

        public MealFoodItemsDetailsViewModel()
            :base()
        {
            Items = new ObservableCollection<MealFoodItems>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

        #region Methods


        public override async void LoadProperties(MealFoodItems item)
        {

            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
        }

        public override void OnUpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task OnEditSelected(int id)
        {
            var dataStore = DependencyService.Get<MealFoodItemService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.MealFoodItemId == id).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(MealFoodItemEditPage)}?{nameof(MealFoodItemsDetailsViewModel.ItemId)}={item.FoodItemID}");
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<MealFoodItemService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.FoodItemID == MealFoodItemId);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
