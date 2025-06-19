using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProPet.DTO;
using ProPet.Models;
using ProPet.Services.Interfaces;

namespace ProPet.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(ITokenServices tokenServices, IAuthServices authServices) : ControllerBase
{
    private readonly IAuthServices _authServices = authServices;
    private readonly ITokenServices _tokenServices = tokenServices;

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }
        
        try
        {
            var user = await _authServices.ValidateLogin(request.Username, request.Password);

            if (user == null) return Unauthorized(new { message = "Username or password is incorrect" });

            var token = _tokenServices.GenerateToken(user.Id, user.Username, user.Role.Descricao);
            return Ok(new { token });
        }
        catch (Exception e)
        {
            return Unauthorized(e);
        }
    }
}