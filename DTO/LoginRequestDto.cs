using System.ComponentModel.DataAnnotations;

namespace ProPet.DTO;

public record LoginRequestDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}