using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Models
{
    public class Habit
        {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserID { get; set; }
       [Required]
        public string Name { get; set; }
        
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Frequency { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}