using ProPet.Models;

namespace ProPet.Services.Interfaces;

public interface IAuthServices
{
    Task<User?> ValidateLogin(string userName, string password);
}