using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequestDto dto)
    {
        var result = await _authenticationService.LoginAsync(dto);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto dto)
    {
        var result = await _authenticationService.RegisterAsync(dto);
        return Ok(result);
    }
}
