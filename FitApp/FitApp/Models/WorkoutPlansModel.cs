namespace FitApp.Models
{
    public class WorkoutPlansModel
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public string PlanDuration { get; set; }
        public string PlanDifficulty { get; set; }
        public int UserID { get; set; }
    }
}
