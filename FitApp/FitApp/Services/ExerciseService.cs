using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class ExerciseService : AListDataStore<Exercises>
    {
        public ExerciseService() :
            base()
        { 
        }

        public override async Task<Exercises> AddItemToService(Exercises item)
        {
            return await _service.ExercisesPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Exercises item)
        {
            return await _service.ExercisesDELETEAsync(item.ExerciseID).HandleRequest();
        }

        public override async Task<Exercises> Find(Exercises item)
        {
            return await _service.ExercisesGETAsync(item.ExerciseID);
        }

        public override async Task<Exercises> Find(int id)
        {
            return await _service.ExercisesGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ExercisesAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Exercises item)
        {
            return await _service.ExercisesPUTAsync(item.ExerciseID, item).HandleRequest();
        }
    }
}
