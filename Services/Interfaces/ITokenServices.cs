namespace ProPet.Services.Interfaces;

public interface ITokenServices
{
    string GenerateToken(int userId, string userName, string role);
}