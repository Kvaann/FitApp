namespace FitApp.Models
{
    public class WorkoutExercisesModel
    {
        public int WorkoutExerciseID { get; set; }
        public int ExerciseID { get; set; }
        public int WorkoutID { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
        public string Weight { get; set; }
    }
}
