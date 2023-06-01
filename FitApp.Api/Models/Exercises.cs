using FitApp.Models;
using System.ComponentModel.DataAnnotations;

namespace FitApp.Api.Models
{
    public class Exercises
    {
        [Key]
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public string ExerciseType { get; set; }
        public string MuscleGroup { get; set; }

        /// <summary>
        /// Relationship with exercises.
        /// </summary>
        public ICollection<WorkoutExercises>? WorkoutExercises { get; set; }
    }
}
