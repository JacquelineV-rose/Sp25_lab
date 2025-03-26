using HabitTrackerAPI.Data;
using HabitTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HabitTrackerAPI.Controllers
{
    [Authorize]
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
            try
            {
                var userIdClaim = User.FindFirst("UserId");
                if (userIdClaim == null)
                {
                    return Unauthorized("UserId claim missing.");
                }

                int userId = int.Parse(userIdClaim.Value);
                var query = _context.Habits.Where(h => h.UserID == userId);

                if (!string.IsNullOrEmpty(frequency))
                {
                    query = query.Where(h => h.Frequency == frequency);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 Error creating habit: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Habit>> CreateHabit(Habit habit)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null)
            {
                return Unauthorized("User ID not found in token.");
            }

            habit.UserID = int.Parse(userIdClaim.Value);

            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHabits), new { id = habit.Id }, habit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(int id)
        {
            var userId = int.Parse(User.FindFirst("UserID")!.Value);
            var habit = await _context.Habits.FirstOrDefaultAsync(h => h.Id == id && h.UserID == userId);
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
            var userId = int.Parse(User.FindFirst("UserID")!.Value);
            if (id != habit.Id || habit.UserID != userId)
            {
                return BadRequest();
            }

            _context.Entry(habit).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}