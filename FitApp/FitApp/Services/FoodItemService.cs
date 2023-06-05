using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class FoodItemService : AListDataStore<FoodItems>
    {
        public FoodItemService() :
            base()
        {
        }

        public override async Task<FoodItems> AddItemToService(FoodItems item)
        {
            return await _service.FoodItemsPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(FoodItems item)
        {
            return await _service.FoodItemsDELETEAsync(item.FoodItemID).HandleRequest();
        }

        public override async Task<FoodItems> Find(FoodItems item)
        {
            return await _service.FoodItemsGETAsync(item.FoodItemID);
        }

        public override async Task<FoodItems> Find(int id)
        {
            return await _service.FoodItemsGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.FoodItemsAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(FoodItems item)
        {
            return await _service.FoodItemsPUTAsync(item.FoodItemID, item).HandleRequest();
        }
    }
}
