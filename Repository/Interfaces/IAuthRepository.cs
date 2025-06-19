using ProPet.Models;

namespace ProPet.Repository.Interfaces;

public interface IAuthRepository
{
    Task<User?> ValidateLogin(string userName, string passwordHash);
}