using Microsoft.EntityFrameworkCore;
using ProPet.Data;
using ProPet.Models;
using ProPet.Repository.Interfaces;

namespace ProPet.Repository;

public class TutorRepository(PetProDbContext context) : ITutorRepository
{
    private readonly PetProDbContext _context = context;

    public async Task<IEnumerable<Tutor>> GetByName(string name)
    {
        return await _context.Tutors
            .Where(tutor => tutor.Nome == name)
            .Include(pet => pet.Pets)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Tutor>> GetAll()
    {
        return await _context.Tutors
            .Include(pet => pet.Pets)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Tutor> Create(Tutor tutor)
    {
        await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }
}