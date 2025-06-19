using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProPet.DTO;
using ProPet.Services.Interfaces;

namespace ProPet.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] 
public class TutorController(ITutorServices tutorServices) : ControllerBase
{
    private readonly ITutorServices _tutorServices = tutorServices;

    [HttpGet]
    [Route("GetByName/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            return Ok(await _tutorServices.GetByName(name));
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _tutorServices.GetAll());
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(CreateTutorDto tutorDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        try
        {
            var result = await _tutorServices.Create(tutorDto);
            return Created("Created", result);
        }
        catch (Exception)
        {
            return BadRequest("Invalid Request");
        }
    }
}