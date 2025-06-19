using ProPet.Models;

namespace ProPet.Repository.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetByName(string name);
    Task<IEnumerable<Tutor>> GetAll();
    Task<Tutor> Create(Tutor tutor);
}