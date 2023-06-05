using FitApp.Models;
using System.ComponentModel.DataAnnotations;

namespace FitApp.Api.Models
{
    public class Workouts : BaseModel
    {
        [Key]
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public string WorkoutDuration { get; set; }
        public string WorkoutDifficulty { get; set; }

        public int? PlanID { get; set; }
        public WorkoutPlans? Plan { get; set; }

        /// <summary>
        /// Relationship with WorkoutExercises.
        /// </summary>
        public ICollection<WorkoutExercises>? WorkoutExercises { get; set; }
    }
}
