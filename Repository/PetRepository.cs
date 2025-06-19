using Microsoft.AspNetCore.StaticAssets.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProPet.Data;
using ProPet.Models;
using ProPet.Repository.Interfaces;

namespace ProPet.Repository;

public class PetRepository(PetProDbContext context) : IPetRepository
{
    private readonly PetProDbContext _context = context;

    public async Task<IEnumerable<Pet>> GetByName(string name)
    {
        return await _context.Pets
            .Where(p => p.Nome == name)
            .Include(p => p.Tutor)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Pet>> GetAll()
    {
        return await _context.Pets
            .Include(p => p.Tutor)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Pet>> GetByTutor(int tutorId)
    {
        return await _context.Pets
            .Where(p => p.TutorId == tutorId)
            .Include(p => p.Tutor)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Pet> Create(Pet pet)
    { 
       await _context.Pets.AddAsync(pet);
       await _context.SaveChangesAsync();
       return pet;
    }
}