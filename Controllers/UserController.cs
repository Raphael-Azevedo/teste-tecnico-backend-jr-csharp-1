using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProPet.DTO;
using ProPet.Services.Interfaces;

namespace ProPet.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] 
public class UserController(IUserServices userServices) : ControllerBase
{
    private readonly IUserServices _userServices = userServices;

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(CreateUserDto userDto)
    {
        try
        {
            var result = await _userServices.Create(userDto);
            return Created("Created", result);
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }
}