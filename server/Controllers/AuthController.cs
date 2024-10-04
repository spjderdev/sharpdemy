using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services.interfaces;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase {
    private readonly IAuthService _userService;

    public AuthController(IAuthService userService) {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDTO userDTO) {
        try {
            var user = await _userService.Register(userDTO);
            return Ok(user);
        } catch (Exception ex) {
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDTO) {
        try {
            var user = await _userService.Login(loginDTO);
            return Ok(user);
        } catch (Exception ex) {
            return BadRequest(new {message = ex.Message});
        }
    }
}