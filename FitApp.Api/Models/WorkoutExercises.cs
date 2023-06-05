using System.ComponentModel.DataAnnotations;

namespace FitApp.Api.Models
{
    public class WorkoutExercises : BaseModel
    {
        [Key]
        public int WorkoutExerciseID { get; set; }

        public int? ExerciseID { get; set; }
        public Exercises? Exercise { get; set; }

        public int? WorkoutID { get; set; }
        public Workouts? Workout { get; set; }

        public string Sets { get; set; }
        public string Reps { get; set; }
        public string Weight { get; set; }
    }
}
