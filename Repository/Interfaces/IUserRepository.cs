using ProPet.Models;

namespace ProPet.Repository.Interfaces;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User?> GetUserByUsername(string username);
}