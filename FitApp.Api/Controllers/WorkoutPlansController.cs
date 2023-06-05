using FitApp.Api.Models;
using FitApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WorkoutPlansController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutPlans>>> GetWorkoutPlans()
        {
          if (_context.WorkoutPlans == null)
          {
              return NotFound();
          }
            return await _context.WorkoutPlans.Include(item=>item.User).ToListAsync();
        }

        // GET: api/WorkoutPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutPlans>> GetWorkoutPlans(int id)
        {
          if (_context.WorkoutPlans == null)
          {
              return NotFound();
          }
            var workoutPlans = await _context.WorkoutPlans.FindAsync(id);

            if (workoutPlans == null)
            {
                return NotFound();
            }

            return workoutPlans;
        }

        // PUT: api/WorkoutPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutPlans(int id, WorkoutPlans workoutPlans)
        {
            if (id != workoutPlans.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(workoutPlans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutPlansExists(id))
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

        // POST: api/WorkoutPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutPlans>> PostWorkoutPlans(WorkoutPlans workoutPlans)
        {
          if (_context.WorkoutPlans == null)
          {
              return Problem("Entity set 'DatabaseContext.WorkoutPlans'  is null.");
          }
            _context.WorkoutPlans.Add(workoutPlans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutPlans", new { id = workoutPlans.PlanId }, workoutPlans);
        }

        // DELETE: api/WorkoutPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutPlans(int id)
        {
            if (_context.WorkoutPlans == null)
            {
                return NotFound();
            }
            var workoutPlans = await _context.WorkoutPlans.FindAsync(id);
            if (workoutPlans == null)
            {
                return NotFound();
            }

            _context.WorkoutPlans.Remove(workoutPlans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutPlansExists(int id)
        {
            return (_context.WorkoutPlans?.Any(e => e.PlanId == id)).GetValueOrDefault();
        }
    }
}
