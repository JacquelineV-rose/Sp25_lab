using System.ComponentModel.DataAnnotations;
namespace HabitTrackerAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}