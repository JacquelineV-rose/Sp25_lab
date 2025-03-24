using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? PasswordHash { get; set; } = string.Empty;
    }
}