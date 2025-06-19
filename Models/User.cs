namespace ProPet.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int UserRoleId { get; set; }
    public int? TutorId { get; set; }
    
    public UserRole Role { get; set; } 
}