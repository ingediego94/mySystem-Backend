using Microsoft.AspNetCore.Mvc;
using mySystem.Application.DTOs;
using mySystem.Application.Interfaces;

namespace mySystem.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // --------------------------------------------------------------
    
    //LOGIN
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var result = await _authService.LoginAsync(request);

        if (result == null)
            return Unauthorized("Incorrect credentials.");

        return Ok(result); // Debe devolver UserAuthResponseDto
    }
    
    

    // REGISTER
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
    {
        var result = await _authService.RegisterAsync(request);

        if (result == null)
            return BadRequest("It hasn't registers the user.");

        return Ok(result); // Debe devolver UserRegisterResponseDto
    }

    
    
    //REFRESH
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshDto request)
    {
        var result = await _authService.RefreshAsync(request);

        if (result == null)
            return Unauthorized("Refresh Token invalid.");

        return Ok(result); // Debe devolver UserAuthResponseDto de nuevo
    }

    
    //REVOKE
    [HttpPost("revoke")]
    public async Task<IActionResult> Revoke([FromBody] RevokeTokenDto request)
    {
        var result = await _authService.RevokeAsync(request);

        if (!result)
            return BadRequest("It hasn't revoke the token.");

        return Ok("Token revoked successfully.");
    }
}