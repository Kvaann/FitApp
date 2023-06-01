using FitApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitApp.Api.Models
{
    public class DatabaseContext : DbContext
    {
        #region Constructor

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }

        #endregion

        #region DbSets

        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<MealFoodItems> MealFoodItems { get; set; }
        public virtual DbSet<FoodItems> FoodItems { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkoutExercises> WorkoutExercises { get; set; }
        public virtual DbSet<WorkoutPlans> WorkoutPlans { get; set; }
        public virtual DbSet<Workouts> Workouts { get; set; }

        #endregion
    }
}
