namespace FitApp.Models
{
    public class WorkoutsModel
    {
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public string WorkoutDuration { get; set; }
        public string WorkoutDifficulty { get; set; }
        public int PlanID { get; set; }
    }
}
