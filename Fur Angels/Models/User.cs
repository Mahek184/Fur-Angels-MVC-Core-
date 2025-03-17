namespace FurAngels.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; } // Made nullable
        public string? Email { get; set; } // Made nullable
        public string? MobileNumber { get; set; } // Made nullable
        public string? PasswordHash { get; set; } // Made nullable
    }
}