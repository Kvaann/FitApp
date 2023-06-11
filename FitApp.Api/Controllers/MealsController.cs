using FitApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MealsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Meals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meals>>> GetMeals()
        {
          if (_context.Meals == null)
          {
              return NotFound();
          }
            return await _context.Meals.Include(item=>item.User).ToListAsync();
        }

        // GET: api/Meals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meals>> GetMeals(int id)
        {
          if (_context.Meals == null)
          {
              return NotFound();
          }
            var meals = await _context.Meals.FindAsync(id);

            if (meals == null)
            {
                return NotFound();
            }

            return meals;
        }

        // PUT: api/Meals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeals(int id, Meals meals)
        {
            if (id != meals.MealID)
            {
                return BadRequest();
            }

            _context.Entry(meals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealsExists(id))
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

        // POST: api/Meals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meals>> PostMeals(Meals meals)
        {
          if (_context.Meals == null)
          {
              return Problem("Entity set 'DatabaseContext.Meals'  is null.");
          }
            _context.Meals.Add(meals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeals", new { id = meals.MealID }, meals);
        }

        // DELETE: api/Meals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeals(int id)
        {
            if (_context.Meals == null)
            {
                return NotFound();
            }
            var meals = await _context.Meals.FindAsync(id);
            if (meals == null)
            {
                return NotFound();
            }

            _context.Meals.Remove(meals);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealsExists(int id)
        {
            return (_context.Meals?.Any(e => e.MealID == id)).GetValueOrDefault();
        }
    }
}
