using FitApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FitApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealFoodItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MealFoodItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MealFoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealFoodItems>>> GetMealFoodItems()
        {
            try
            {
                if (_context.MealFoodItems == null)
                {
                    return NotFound();
                }
                var model = await _context.MealFoodItems
                    .Include(item => item.Meal)
                    .ThenInclude(item => item.User)
                    .Include(item => item.FoodItem)
                    .ToListAsync();
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/MealFoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealFoodItems>> GetMealFoodItems(int id)
        {
          if (_context.MealFoodItems == null)
          {
              return NotFound();
          }
            var mealFoodItems = await _context.MealFoodItems.FindAsync(id);

            if (mealFoodItems == null)
            {
                return NotFound();
            }

            return mealFoodItems;
        }

        // PUT: api/MealFoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealFoodItems(int id, MealFoodItems mealFoodItems)
        {
            if (id != mealFoodItems.MealFoodItemId)
            {
                return BadRequest();
            }

            _context.Entry(mealFoodItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealFoodItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MealFoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealFoodItems>> PostMealFoodItems(MealFoodItems mealFoodItems)
        {
          if (_context.MealFoodItems == null)
          {
              return Problem("Entity set 'DatabaseContext.MealFoodItems'  is null.");
          }
            _context.MealFoodItems.Add(mealFoodItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealFoodItems", new { id = mealFoodItems.MealFoodItemId }, mealFoodItems);
        }

        // DELETE: api/MealFoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealFoodItems(int id)
        {
            if (_context.MealFoodItems == null)
            {
                return NotFound();
            }
            var mealFoodItems = await _context.MealFoodItems.FindAsync(id);
            if (mealFoodItems == null)
            {
                return NotFound();
            }

            _context.MealFoodItems.Remove(mealFoodItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealFoodItemsExists(int id)
        {
            return (_context.MealFoodItems?.Any(e => e.MealFoodItemId == id)).GetValueOrDefault();
        }
    }
}
