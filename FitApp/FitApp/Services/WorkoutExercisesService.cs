using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class WorkoutExercisesService : AListDataStore<WorkoutExercises>
    {
        public WorkoutExercisesService() :
            base()
        { }

        public override async Task<WorkoutExercises> AddItemToService(WorkoutExercises item)
        {
            return await _service.WorkoutExercisesPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(WorkoutExercises item)
        {
            return await _service.WorkoutExercisesDELETEAsync(item.WorkoutExerciseID).HandleRequest();
        }

        public override async Task<WorkoutExercises> Find(WorkoutExercises item)
        {
            return await _service.WorkoutExercisesGETAsync(item.WorkoutExerciseID);
        }

        public override async Task<WorkoutExercises> Find(int id)
        {
            return await _service.WorkoutExercisesGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.WorkoutExercisesAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(WorkoutExercises item)
        {
            return await _service.WorkoutExercisesPUTAsync(item.WorkoutExerciseID, item).HandleRequest();
        }

    }
}
