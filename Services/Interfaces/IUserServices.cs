using ProPet.DTO;
using ProPet.Models;

namespace ProPet.Services.Interfaces;

public interface IUserServices
{
    Task<string> Create(CreateUserDto userDto);
}