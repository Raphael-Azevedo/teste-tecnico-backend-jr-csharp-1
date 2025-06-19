using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProPet.DTO;
using ProPet.Services.Interfaces;

namespace ProPet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController(IPetServices petServices) : ControllerBase
{
    private readonly IPetServices _petServices = petServices;

    [HttpGet]
    [Route("GetByName/{name}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            return Ok(await _petServices.GetByName(name));
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }

    [HttpGet]
    [Route("GetAll")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _petServices.GetAll());
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }

    [HttpGet]
    [Route("GetByTutor/{tutorId:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByTutor(int tutorId)
    {
        if (tutorId == 0)
        {
            return BadRequest("Invalid Tutor");
        }

        try
        {
            return Ok(await _petServices.GetByTutor(tutorId));
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }

    [HttpPost]
    [Route("Create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreatePetDto createPetDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        try
        {
            var result = await _petServices.Create(createPetDto);
            return Created("Created", result);
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }

    [HttpGet]
    [Route("GetUserSessionPets")]
    public async Task<IActionResult> GetUserSessionPets()
    {
        var tutorIdClaim = User.FindFirst("userId")?.Value;

        if (string.IsNullOrWhiteSpace(tutorIdClaim) || !int.TryParse(tutorIdClaim, out var tutorId))
        {
            return NotFound("Tutor Not Found");
        }

        try
        {
            return Ok(await _petServices.GetByTutor(tutorId));
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }
}