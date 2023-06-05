using FitApp.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace FitApp.Models
{
    public class Users : BaseModel
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string ActivityLevel { get; set; }

        /// <summary>
        /// Relationship with workout plans.
        /// </summary>
        public ICollection<Users>? WorkoutPlans { get; set; }

        /// <summary>
        /// Relationship with meals.
        /// </summary>
        public ICollection<Meals>? Meals { get; set; }
    }
}
