using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class WorkoutService : AListDataStore<Workouts>
    {
        public WorkoutService() :
            base()
        { }

        public override async Task<Workouts> AddItemToService(Workouts item)
        {
            return await _service.WorkoutsPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Workouts item)
        {
            return await _service.WorkoutsDELETEAsync(item.WorkoutID).HandleRequest();
        }

        public override async Task<Workouts> Find(Workouts item)
        {
            return await _service.WorkoutsGETAsync(item.WorkoutID);
        }

        public override async Task<Workouts> Find(int id)
        {
            return await _service.WorkoutsGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.WorkoutsAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Workouts item)
        {
            return await _service.WorkoutsPUTAsync(item.WorkoutID, item).HandleRequest();
        }

    }
}