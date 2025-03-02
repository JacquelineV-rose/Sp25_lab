namespace HabitTracker.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Frequency { get; set; }
        public bool Completed { get; set; }
    }
}