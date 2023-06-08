using FitApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ExercisesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercises>>> GetExercises()
        {
            if (_context.Exercises == null)
            {
                return NotFound();
            }
            return await _context.Exercises.ToListAsync();
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercises>> GetExercises(int id)
        {
            if (_context.Exercises == null)
            {
                return NotFound();
            }
            var exercises = await _context.Exercises.FindAsync(id);

            if (exercises == null)
            {
                return NotFound();
            }

            return exercises;
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercises(int id, Exercises exercises)
        {
            if (id != exercises.ExerciseID)
            {
                return BadRequest();
            }

            _context.Entry(exercises).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercisesExists(id))
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

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercises>> PostExercises(Exercises exercises)
        {
          if (_context.Exercises == null)
          {
              return Problem("Entity set 'DatabaseContext.Exercises'  is null.");
          }
            _context.Exercises.Add(exercises);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercises", new { id = exercises.ExerciseID }, exercises);
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercises(int id)
        {
            if (_context.Exercises == null)
            {
                return NotFound();
            }
            var exercises = await _context.Exercises.FindAsync(id);
            if (exercises == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercises);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercisesExists(int id)
        {
            return (_context.Exercises?.Any(e => e.ExerciseID == id)).GetValueOrDefault();
        }
    }
}
