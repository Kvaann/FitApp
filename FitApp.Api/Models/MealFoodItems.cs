using System.ComponentModel.DataAnnotations;

namespace FitApp.Api.Models
{
    public class MealFoodItems : BaseModel
    {
        [Key]
        public int MyProperty { get; set; }

        public int? FoodItemID { get; set; }
        public FoodItems? FoodItem { get; set; }

        public int? MealID { get; set; }
        public Meals? Meal { get; set; }

        public string ServingSize { get; set; }
        public string ServingsPerMeal { get; set; }
    }
}
