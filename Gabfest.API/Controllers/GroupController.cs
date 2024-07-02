using AutoMapper;
using Gabfest.Data;
using Gabfest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gabfest.API;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;

    public GroupController(IGroupService groupService, IMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ReturnModel> Get([FromQuery] PaginationModel paginationModel)
    {
        var groups = await _groupService.GetAllAsync(paginationModel);
        return new ReturnModel
        {
            Success = true,
            Message = "Groups fetched successfully",
            Data = _mapper.Map<IEnumerable<GroupModel>>(groups),
            StatusCode = 200,
            TotalCount = await _groupService.CountAsync()
        };
    }

    [HttpGet("{id}")]
    public async Task<ReturnModel> Get(int id)
    {
        var group = await _groupService.GetByIdAsync(id);
        return new ReturnModel
        {
            Success = true,
            Message = "Group fetched successfully",
            Data = _mapper.Map<GroupModel>(group),
            StatusCode = 200
        };
    }

    [HttpPost]
    public async Task<ReturnModel> Post([FromBody] GroupCreateModel groupCreateModel)
    {
        var group = _mapper.Map<Group>(groupCreateModel);
        var groupResult = await _groupService.AddAsync(group);
        return new ReturnModel
        {
            Success = true,
            Message = "Group added successfully",
            Data = _mapper.Map<GroupModel>(groupResult),
            StatusCode = 200
        };
    }


    [HttpPut]
    public async Task<ReturnModel> Put([FromBody] GroupUpdateModel groupUpdateModel)
    {
        var group = _mapper.Map<Group>(groupUpdateModel);
        var groupResult = await _groupService.UpdateAsync(group);
        return new ReturnModel
        {
            Success = true,
            Message = "Group updated successfully",
            Data = _mapper.Map<GroupModel>(groupResult),
            StatusCode = 200
        };
    }

    [HttpDelete("{id}")]
    public async Task<ReturnModel> Delete(int id)
    {
        var group = await _groupService.GetByIdAsync(id);
        await _groupService.DeleteAsync(group);
        return new ReturnModel
        {
            Success = true,
            Message = "Group deleted successfully",
            StatusCode = 200
        };
    }
}
