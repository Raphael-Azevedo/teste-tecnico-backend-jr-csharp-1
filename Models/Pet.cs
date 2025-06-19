using System.Text.Json.Serialization;

namespace ProPet.Models;

public class Pet
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; } 
    public string Raca { get; set; } 
    public int Idade { get; set; }

    // Chave estrangeira para o Tutor
    public int TutorId { get; set; }

    // Propriedade de navegação para o Tutor
    [JsonIgnore] 
    public Tutor Tutor { get; set; }
}