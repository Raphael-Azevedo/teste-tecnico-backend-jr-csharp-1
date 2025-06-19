using System.ComponentModel.DataAnnotations;

namespace ProPet.DTO;

public record CreateUserDto
{
    [Required]
    [MaxLength()]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public int? TutorId { get; set; }
}