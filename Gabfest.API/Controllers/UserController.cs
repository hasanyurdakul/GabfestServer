using AutoMapper;
using Gabfest.Data;
using Gabfest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gabfest.API;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ReturnModel> Get([FromQuery] PaginationModel paginationModel)
    {
        var users = await _userService.GetAllAsync(paginationModel);
        return new ReturnModel
        {
            Success = true,
            Message = "Users fetched successfully",
            Data = _mapper.Map<IEnumerable<UserModel>>(users),
            StatusCode = 200,
            TotalCount = await _userService.CountAsync()
        };
    }

    [HttpGet("{id}")]
    public async Task<ReturnModel> Get(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return new ReturnModel
        {
            Success = true,
            Message = "User fetched successfully",
            Data = user,
            StatusCode = 200
        };
    }

    [HttpPost]
    public async Task<ReturnModel> Post([FromBody] UserCreateModel userCreateModel)
    {
        var newUser = _mapper.Map<User>(userCreateModel);
        var createdUser = await _userService.AddAsync(newUser);
        return new ReturnModel
        {
            Success = true,
            Message = "User created successfully",
            Data = createdUser,
            StatusCode = 201
        };
    }

    [HttpPut]
    public async Task<ReturnModel> Put([FromBody] UserUpdateModel userUpdateModel)
    {
        var userToBeUpdated = _mapper.Map<User>(userUpdateModel);
        var updatedUser = await _userService.UpdateAsync(userToBeUpdated);
        return new ReturnModel
        {
            Success = true,
            Message = $"User with ID: {userUpdateModel.Id} updated successfully",
            Data = _mapper.Map<UserModel>(updatedUser),
            StatusCode = 200
        };
    }

    [HttpDelete("{id}")]
    public async Task<ReturnModel> Delete(int id)
    {
        var userFromDatabase = await _userService.GetByIdAsync(id);
        await _userService.DeleteAsync(userFromDatabase);
        return new ReturnModel
        {
            Success = true,
            Message = $"User with ID: {id} deleted successfully",
            StatusCode = 200
        };
    }
}
