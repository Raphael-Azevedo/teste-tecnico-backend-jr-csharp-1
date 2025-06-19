using System.Text.Json.Serialization;

namespace ProPet.Models;

public class Tutor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string SobreNome { get; set; }
    public string Endereco { get; set; }
    public string NumeroContato { get; set; }

    // Propriedade de navegação para os pets do tutor
    [JsonIgnore] 
    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
}