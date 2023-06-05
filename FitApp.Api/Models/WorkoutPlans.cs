using FitApp.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace FitApp.Models
{
    public class WorkoutPlans : BaseModel
    {
        [Key]
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public string PlanDuration { get; set; }
        public string PlanDifficulty { get; set; }

        /// <summary>
        /// Relationship with user.
        /// </summary>
        public int? UserID { get; set; }
        public Users? User { get; set; }

        /// <summary>
        /// Relationship with Workouts.
        /// </summary>
        public ICollection<Workouts>? Workouts { get; set; }
    }
}
