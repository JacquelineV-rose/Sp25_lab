namespace HabitTrackerAPI.DTOs
{
    public class UserRegisterDto
    {
        public string Username { get; set; } = string.Empty; //or required
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}