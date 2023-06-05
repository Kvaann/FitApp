using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class WorkoutPlansService : AListDataStore<WorkoutPlans>
    {
        public WorkoutPlansService() :
            base()
        { }

        public override async Task<WorkoutPlans> AddItemToService(WorkoutPlans item)
        {
            return await _service.WorkoutPlansPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(WorkoutPlans item)
        {
            return await _service.WorkoutPlansDELETEAsync(item.PlanId).HandleRequest();
        }

        public override async Task<WorkoutPlans> Find(WorkoutPlans item)
        {
            return await _service.WorkoutPlansGETAsync(item.PlanId);
        }

        public override async Task<WorkoutPlans> Find(int id)
        {
            return await _service.WorkoutPlansGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.WorkoutPlansAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(WorkoutPlans item)
        {
            return await _service.WorkoutPlansPUTAsync(item.PlanId, item).HandleRequest();
        }

    }
}