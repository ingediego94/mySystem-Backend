using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mySystem.Application.DTOs;
using mySystem.Application.Interfaces;

namespace mySystem.Api.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    // ------------------------------------------------
    
    // GetAll:
    [Authorize(Roles = "Admin, User")]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();

        if (users == null)
            return NotFound(
                new { message = "None user has been registered yet." }
            );
        
        return Ok(users);
    }
    
    
    // Get By Id:
    [Authorize(Roles="Admin, User")]
    [HttpGet("getById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);

        if (user == null)
            return NotFound(
                new { message = $"User with if '{id}' not found." }
                ); 
                
        return Ok(user);
    }
    
    
    // Update:
    [Authorize(Roles = "Admin, User")]
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedUser = await _userService.UpdateAsync(id, dto);

        if (updatedUser == null)
            return NotFound(
                new { message = $"User with id '{id}' not founded." }
            );

        return Ok(
            new { message = $"User updated successfully", updatedUser }
        );
    }
        
        
    
    // Delete:
    [Authorize(Roles = "Admin")]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var toDelete = await _userService.DeleteAsync(id);

        if (!toDelete)
            return NotFound(
                new { message = $"User with id '{id}' not found" }
            );
        
        return Ok(
            new {message = $"User with id '{id}' deleted successfully."}
            );
    }
}