using System.ComponentModel.DataAnnotations;

namespace ProPet.DTO;

public record CreatePetDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Tipo { get; set; } 
    [Required]
    public string Raca { get; set; } 
    [Required]
    public int Idade { get; set; }
    [Required]
    public int TutorId { get; set; }   
}