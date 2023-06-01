using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitApp.Models
{
    public class WorkoutPlans
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
        public int UserID { get; set; }
        public Users User { get; set; }
    }
}
