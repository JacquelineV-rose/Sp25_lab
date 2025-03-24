using HabitTrackerAPI.Data;
using HabitTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Controllers
{
    [Route("api/habits")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HabitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habit>>> GetHabits([FromQuery] string? frequency)
        {
            var query = _context.Habits.AsQueryable();

            if (!string.IsNullOrEmpty(frequency))
            {
                query = query.Where(h => h.Frequency == frequency);
            }

            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Habit>> CreateHabit(Habit habit)
        {
            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHabits), new { id = habit.Id }, habit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }

            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabit(int id, Habit habit)
        {
            if (id != habit.Id) return BadRequest();

            _context.Entry(habit).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}