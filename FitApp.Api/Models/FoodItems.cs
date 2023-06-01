using System.ComponentModel.DataAnnotations;

namespace FitApp.Api.Models
{
    public class FoodItems
    {
        [Key]
        public int FoodItemID { get; set; }
        public string FoodItemName { get; set; }
        public string FoodItemDescription { get; set; }
        public string FoodItemCalories { get; set; }

        /// <summary>
        /// Relationship with MealFoodItems.
        /// </summary>
        public ICollection<MealFoodItems>? MealFoodItems { get; set; }
    }
}
