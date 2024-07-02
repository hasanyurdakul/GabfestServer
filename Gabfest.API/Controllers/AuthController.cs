using Gabfest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gabfest.API;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("Login")]
    public async Task<ReturnModel> Login([FromBody] LoginModel loginModel)
    {
        var user = await _userService.GetUserByUsernameAndPasswordAsync(loginModel.Username, loginModel.Password);
        if (user == null)
        {
            return new ReturnModel
            {
                Success = false,
                Message = "Invalid username or password",
                StatusCode = 400
            };
        }
        var tokenModel = new TokenModel
        {
            Username = user.Username,
            Role = user.Role,
            SigningKey = _configuration["JWT:SigningKey"],
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"]
        };
        var token = JWTHelper.GenerateJWT(tokenModel);
        return new ReturnModel
        {
            Success = true,
            Message = "Login successful",
            StatusCode = 200,
            Data = token
        };

    }

}
