using FitApp.ViewModels.Abstract;
using FitApp.Views.FoodItemView;
using FitAppApi;
using Xamarin.Forms;

namespace FitApp.ViewModels.FoodItemsViewModel
{
    public class FoodItemsViewModel : AListViewModel<FoodItems>
    {
        public FoodItemsViewModel()
            : base("Food Items")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewFoodItemPage));
        }

        public override async void OnItemSelected(FoodItems item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(FoodItemDetailsPage)}?{nameof(FoodItemsDetailsViewModel.ItemId)}={item.FoodItemID}");
        }
    }
}
