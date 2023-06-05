using FitApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace FitApp.Api.Models
{
    public class Meals : BaseModel
    {
        [Key]
        public int MealID { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealCalories { get; set; }

        public int? UserID { get; set; }
        public Users? User { get; set; }

        /// <summary>
        /// Relationship with MealFoodItems.
        /// </summary>
        public ICollection<MealFoodItems>? MealFoodItems { get; set; }
    }
}
