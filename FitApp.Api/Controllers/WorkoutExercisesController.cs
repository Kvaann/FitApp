using FitApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutExercisesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WorkoutExercisesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutExercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutExercises>>> GetWorkoutExercises()
        {
          if (_context.WorkoutExercises == null)
          {
              return NotFound();
          }
            return await _context.WorkoutExercises
                .Include(item => item.Exercise)
                .Include(item => item.Workout)
                .ToListAsync();
        }

        // GET: api/WorkoutExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutExercises>> GetWorkoutExercises(int id)
        {
          if (_context.WorkoutExercises == null)
          {
              return NotFound();
          }
            var workoutExercises = await _context.WorkoutExercises.FindAsync(id);

            if (workoutExercises == null)
            {
                return NotFound();
            }

            return workoutExercises;
        }

        // PUT: api/WorkoutExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutExercises(int id, WorkoutExercises workoutExercises)
        {
            if (id != workoutExercises.WorkoutExerciseID)
            {
                return BadRequest();
            }

            _context.Entry(workoutExercises).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExercisesExists(id))
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

        // POST: api/WorkoutExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutExercises>> PostWorkoutExercises(WorkoutExercises workoutExercises)
        {
          if (_context.WorkoutExercises == null)
          {
              return Problem("Entity set 'DatabaseContext.WorkoutExercises'  is null.");
          }
            _context.WorkoutExercises.Add(workoutExercises);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutExercises", new { id = workoutExercises.WorkoutExerciseID }, workoutExercises);
        }

        // DELETE: api/WorkoutExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutExercises(int id)
        {
            if (_context.WorkoutExercises == null)
            {
                return NotFound();
            }
            var workoutExercises = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercises == null)
            {
                return NotFound();
            }

            _context.WorkoutExercises.Remove(workoutExercises);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutExercisesExists(int id)
        {
            return (_context.WorkoutExercises?.Any(e => e.WorkoutExerciseID == id)).GetValueOrDefault();
        }
    }
}
