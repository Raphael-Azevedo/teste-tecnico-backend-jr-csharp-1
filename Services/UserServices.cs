using ProPet.DTO;
using ProPet.Enums;
using ProPet.Models;
using ProPet.Repository.Interfaces;
using ProPet.Services.Interfaces;

namespace ProPet.Services;

public class UserServices(IUserRepository userRepository) : IUserServices
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<string> Create(CreateUserDto userDto)
    {
        User user = new User();
        user.Username = userDto.Username;
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        user.TutorId = userDto.TutorId;
        user.UserRoleId = (int)UserRoleEnum.Normal;

        await _userRepository.Create(user);

        return user.Username;
    }
}