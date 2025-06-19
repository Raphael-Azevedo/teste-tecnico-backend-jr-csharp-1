using Microsoft.EntityFrameworkCore;
using ProPet.Data;
using ProPet.Models;
using ProPet.Repository.Interfaces;

namespace ProPet.Repository;

public class AuthRepository(PetProDbContext context) : IAuthRepository
{
    private readonly PetProDbContext _context = context;

    public async Task<User?> ValidateLogin(string userName, string passwordHash)
    {
        return await _context.Users.Where(u => u.Username == userName && u.PasswordHash == passwordHash)
            .FirstOrDefaultAsync();
    }
}