using Microsoft.EntityFrameworkCore;
using ProPet.Data;
using ProPet.Models;
using ProPet.Repository.Interfaces;

namespace ProPet.Repository;

public class UserRepository(PetProDbContext context) : IUserRepository
{
    private readonly PetProDbContext _context = context;

    public async Task<User> Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByUsername(string userName)
    {
        return await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Username == userName);
    }
}