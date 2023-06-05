using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class MealsModelService : AListDataStore<Meals>
    {
        public MealsModelService() :
            base()
        {
        }

        public override async Task<Meals> AddItemToService(Meals item)
        {
            return await _service.MealsPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Meals item)
        {
            return await _service.MealsDELETEAsync(item.MealID).HandleRequest();
        }

        public override async Task<Meals> Find(Meals item)
        {
            return await _service.MealsGETAsync(item.MealID);
        }

        public override async Task<Meals> Find(int id)
        {
            return await _service.MealsGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.MealsAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Meals item)
        {
            return await _service.MealsPUTAsync(item.MealID, item).HandleRequest();
        }
    }
}
