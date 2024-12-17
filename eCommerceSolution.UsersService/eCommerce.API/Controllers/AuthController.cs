using eCommerce.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;


namespace eCommerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UsersService _usersService;

    public AuthController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("register")] // POST api/auth/register
    public async Task<IActionResult> Register
        (RegisterRequest registerRequest)
    {
        if(registerRequest is null) return BadRequest("Invalid registration data");

        //Call the register method of the service

        AuthenticationResponse? authenticationResponse = 
            await _usersService.Register(registerRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
            return BadRequest(authenticationResponse);

        return Ok(authenticationResponse);
    }

    /// <summary>
    /// Endpoint to handle user login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult?> Login
        (LoginRequest loginRequest)
    {
        if (loginRequest is null) BadRequest("Invalid login data");

        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false) return BadRequest(authenticationResponse);
        
        return Ok(authenticationResponse);
    }
}
