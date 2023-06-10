using FitApp.ViewModels.Abstract;
using FitApp.Views.MealFoodItemView;
using FitAppApi;
using Xamarin.Forms;

namespace FitApp.ViewModels.MealFoodItemsViewModel
{
    public class MealFoodItemsViewModel : AListViewModel<MealFoodItems>
    {
        public MealFoodItemsViewModel()
            : base("Meal Food Item")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewMealFoodItemPage));
        }

        public override async void OnItemSelected(MealFoodItems item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(MealFoodItemDetailsPage)}?{nameof(MealFoodItemsDetailsViewModel.ItemId)}={item.FoodItemID}");
        }
    }
}
