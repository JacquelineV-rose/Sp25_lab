using HabitTrackerAPI.Data;
using HabitTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HabitTrackerAPI.Controllers
{

    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Note>> GetNotes()
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null)
            {
                return Unauthorized("User ID not found in token.");
            }

            int userId = int.Parse(userIdClaim.Value);
            var note = await _context.Notes
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .FirstOrDefaultAsync();

            return note ?? new Note { Content = "" };
        }

        [HttpPost]
        public async Task<IActionResult> SaveNote([FromBody] Note note)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null)
            {
                return Unauthorized("User ID not found in token.");
            }

            int userId = int.Parse(userIdClaim.Value);
            var existing = await _context.Notes.FirstOrDefaultAsync(n => n.UserId == userId);

            if (existing != null)
            {
                existing.Content = note.Content;
                existing.CreatedAt = DateTime.UtcNow;
            }
            else
            {
                note.UserId = userId;
                note.CreatedAt = DateTime.UtcNow;
                _context.Notes.Add(note);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}