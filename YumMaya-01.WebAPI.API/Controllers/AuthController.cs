using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YumMaya_01.WebAPI.Application.Contracts.Auth;
using YumMaya_01.WebAPI.Application.Contracts.Services;
using YumMaya_01.WebAPI.Application.DTOs.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YumMaya_01.WebAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    // POST: api/Auth
    /// <summary>
    /// Authenticate user
    /// </summary>
    /// <param name="loginDto"></param>
    /// <returns>JWT Token</returns>
    [HttpPost]
    public async Task<IActionResult> Post(LoginDto loginDto)
    {
        var sw = Stopwatch.StartNew();
        var token = await _authService.LoginAsync(loginDto);

        var minDuration = TimeSpan.FromSeconds(2);
        var elapsed = sw.Elapsed;

        if (elapsed < minDuration)
            await Task.Delay(minDuration - elapsed);

        if (token == null)
            return Unauthorized();

        return Ok(new { Token = token });
    }
}
