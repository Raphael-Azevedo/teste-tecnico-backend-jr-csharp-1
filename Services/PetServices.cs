using ProPet.DTO;
using ProPet.Models;
using ProPet.Repository.Interfaces;
using ProPet.Services.Interfaces;

namespace ProPet.Services;

public class PetServices(IPetRepository petRepository) : IPetServices
{
    private readonly IPetRepository _petRepository = petRepository;

    public async Task<IEnumerable<Pet>> GetByName(string name)
    {
        return await _petRepository.GetByName(name);
    }

    public async Task<IEnumerable<Pet>> GetAll()
    {
        return await _petRepository.GetAll();
    }

    public async Task<IEnumerable<Pet>> GetByTutor(int tutorId)
    {
        return await _petRepository.GetByTutor(tutorId);
    }

    public async Task<Pet> Create(CreatePetDto petDto)
    {
        Pet pet = new Pet()
        {
            Nome = petDto.Nome,
            Tipo = petDto.Tipo,
            Raca = petDto.Raca,
            Idade = petDto.Idade,
            TutorId = petDto.TutorId
        };

        await _petRepository.Create(pet);
        return pet;
    }
}