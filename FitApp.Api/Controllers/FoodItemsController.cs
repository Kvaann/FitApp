using FitApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FoodItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItems>>> GetFoodItems()
        {
          if (_context.FoodItems == null)
          {
              return NotFound();
          }
            return await _context.FoodItems.ToListAsync();
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItems>> GetFoodItems(int id)
        {
          if (_context.FoodItems == null)
          {
              return NotFound();
          }
            var foodItems = await _context.FoodItems.FindAsync(id);

            if (foodItems == null)
            {
                return NotFound();
            }

            return foodItems;
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItems(int id, FoodItems foodItems)
        {
            if (id != foodItems.FoodItemID)
            {
                return BadRequest();
            }

            _context.Entry(foodItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemsExists(id))
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

        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItems>> PostFoodItems(FoodItems foodItems)
        {
          if (_context.FoodItems == null)
          {
              return Problem("Entity set 'DatabaseContext.FoodItems'  is null.");
          }
            _context.FoodItems.Add(foodItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodItems", new { id = foodItems.FoodItemID }, foodItems);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItems(int id)
        {
            if (_context.FoodItems == null)
            {
                return NotFound();
            }
            var foodItems = await _context.FoodItems.FindAsync(id);
            if (foodItems == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(foodItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodItemsExists(int id)
        {
            return (_context.FoodItems?.Any(e => e.FoodItemID == id)).GetValueOrDefault();
        }
    }
}
