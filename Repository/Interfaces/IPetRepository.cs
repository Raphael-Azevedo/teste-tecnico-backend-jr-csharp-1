using ProPet.Models;

namespace ProPet.Repository.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetByName(string name);
    Task<IEnumerable<Pet>> GetAll();
    Task<IEnumerable<Pet>> GetByTutor(int tutorId);
    Task<Pet> Create(Pet pet);
}