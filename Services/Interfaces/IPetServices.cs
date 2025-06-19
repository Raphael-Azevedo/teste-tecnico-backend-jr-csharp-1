using ProPet.DTO;
using ProPet.Models;

namespace ProPet.Services.Interfaces;

public interface IPetServices
{
    Task<IEnumerable<Pet>> GetByName(string name);
    Task<IEnumerable<Pet>> GetAll();
    Task<IEnumerable<Pet>> GetByTutor(int tutorId);
    Task<Pet> Create(CreatePetDto pet);
}