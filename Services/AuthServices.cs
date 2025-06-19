using ProPet.Models;
using ProPet.Repository.Interfaces;
using ProPet.Services.Interfaces;

namespace ProPet.Services;

public class AuthServices(IUserRepository userRepository) : IAuthServices
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User?> ValidateLogin(string userName, string password)
    {
        var user = await _userRepository.GetUserByUsername(userName);

        if (user == null)
        {
            return null;
        }

        return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;
    }
}