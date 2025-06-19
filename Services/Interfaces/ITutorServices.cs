using ProPet.DTO;
using ProPet.Models;

namespace ProPet.Services.Interfaces;

public interface ITutorServices
{
    Task<IEnumerable<Tutor>> GetByName(string name);
    Task<IEnumerable<Tutor>> GetAll();
    Task<Tutor> Create(CreateTutorDto tutorDto);
}