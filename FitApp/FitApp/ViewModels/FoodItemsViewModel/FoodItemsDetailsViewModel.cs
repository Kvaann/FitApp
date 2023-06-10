using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.FoodItemView;
using FitAppApi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.FoodItemsViewModel
{
    public class FoodItemsDetailsViewModel : AItemDatailsViewModel<FoodItems>
    {
        public FoodItemsDetailsViewModel()
            : base()
        {
            Items = new ObservableCollection<FoodItems>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

        #region Fields

        private int id;
        private string foodItemName;
        private string foodItemDescription;
        private string foodItemCalories;

        #endregion Fields

        #region Properties

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
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

        public ObservableCollection<FoodItems> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion Properties

        public override async void LoadProperties(FoodItems item)
        {
            FoodItemName = item.FoodItemName;
            FoodItemDescription = item.FoodItemDescription;
            FoodItemCalories = item.FoodItemCalories;
            Title = "Food Item Details";
            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<FoodItemService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item => item.FoodItemID == Id);
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

        public async Task OnEditSelected(int id)
        {
            var dataStore = DependencyService.Get<FoodItemService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.FoodItemID == id).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(FoodItemEditPage)}?{nameof(FoodItemsDetailsViewModel.ItemId)}={item.FoodItemID}");
        }

        public override async void OnUpdateAsync()
        {
            var dataStore = DependencyService.Get<FoodItemService>();
            var Item = (await dataStore.GetItemsAsync(true)).Where(item => item.FoodItemID == ItemId).First();
            Item.ModificationDate = DateTime.Now;
            Item.FoodItemName = this.FoodItemName;
            Item.FoodItemDescription = this.FoodItemDescription;
            Item.FoodItemCalories = this.FoodItemCalories;
            await DataStore.UpdateItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }
    }
}