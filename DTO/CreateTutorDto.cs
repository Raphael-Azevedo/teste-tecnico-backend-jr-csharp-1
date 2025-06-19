using System.ComponentModel.DataAnnotations;

namespace ProPet.DTO;

public record CreateTutorDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string SobreNome { get; set; }
    [Required]
    public string Endereco { get; set; }
    [Required]
    public string NumeroContato { get; set; }
}