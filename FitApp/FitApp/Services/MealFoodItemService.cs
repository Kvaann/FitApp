using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class MealFoodItemService : AListDataStore<MealFoodItems>
    {
        public MealFoodItemService() :
            base()
        {
        }

        public override async Task<MealFoodItems> AddItemToService(MealFoodItems item)
        {
            return await _service.MealFoodItemsPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(MealFoodItems item)
        {
            return await _service.MealFoodItemsDELETEAsync(item.MealFoodItemId).HandleRequest();
        }

        public override async Task<MealFoodItems> Find(MealFoodItems item)
        {
            return await _service.MealFoodItemsGETAsync(item.MealFoodItemId);
        }

        public override async Task<MealFoodItems> Find(int id)
        {
            return await _service.MealFoodItemsGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.MealFoodItemsAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(MealFoodItems item)
        {
            return await _service.MealFoodItemsPUTAsync(item.MealFoodItemId, item).HandleRequest();
        }
    }
}
