namespace Task2.Models
{
    public class AppUser
    {
        public int UserId { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
