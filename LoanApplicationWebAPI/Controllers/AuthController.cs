using LoanApplicationWebAPI.Helpers;
using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using LoanApplicationWebAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly JwtHelper _jwtHelper;

    public AuthController(IUserService userService, JwtHelper jwtHelper)
    {
        _userService = userService;
        _jwtHelper = jwtHelper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var user = await _userService.LoginAsync(model);
        if (user == null)
        {
            return Unauthorized(new LoginResponseViewModel
            {
                IsSuccess = false,
                Message = "Invalid username or password"
            });
        }

        // Combine first name and last name into FullName
        //var fullName = $"{user.FirstName} {user.LastName}";
        //var fullname = user.FullName;

        // Generate JWT token
        var token = _jwtHelper.GenerateToken(user.UserId, user.FullName, user.Role.ToString());

        var response = new LoginResponseViewModel
        {
            UserId = user.UserId,
            FullName = user.FullName,
            Role = user.Role.ToString(),
            Token = token,
            IsSuccess = true,
            Message = "Login successful"
        };

        return Ok(response);
    }
}
