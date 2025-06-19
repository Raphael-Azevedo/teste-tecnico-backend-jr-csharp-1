using ProPet.DTO;
using ProPet.Models;
using ProPet.Repository.Interfaces;
using ProPet.Services.Interfaces;

namespace ProPet.Services;

public class TutorServices(ITutorRepository tutorRepository) : ITutorServices
{
    private readonly ITutorRepository _tutorRepository = tutorRepository;

    public async Task<IEnumerable<Tutor>> GetByName(string name)
    {
        return await _tutorRepository.GetByName(name);
    }

    public async Task<IEnumerable<Tutor>> GetAll()
    {
        return await _tutorRepository.GetAll();
    }

    public async Task<Tutor> Create(CreateTutorDto tutorDto)
    {
        Tutor tutor = new Tutor();
        tutor.Nome = tutorDto.Nome;
        tutor.Endereco = tutorDto.Endereco;
        tutor.NumeroContato = tutorDto.NumeroContato;
        tutor.SobreNome = tutorDto.SobreNome;

        await _tutorRepository.Create(tutor);

        return tutor;
    }
}