using AutoMapper;
using Gabfest.Data;
using Gabfest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gabfest.API;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public MessageController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ReturnModel> Get([FromQuery] PaginationModel paginationModel)
    {
        var messages = await _messageService.GetAllAsync(paginationModel);
        return new ReturnModel
        {
            Success = true,
            Message = "Messages fetched successfully",
            Data = _mapper.Map<IEnumerable<MessageModel>>(messages),
            StatusCode = 200,
            TotalCount = await _messageService.CountAsync()
        };
    }

    [HttpGet("{id}")]
    public async Task<ReturnModel> Get(int id)
    {
        var message = await _messageService.GetByIdAsync(id);
        return new ReturnModel
        {
            Success = true,
            Message = "Message fetched successfully",
            Data = _mapper.Map<MessageModel>(message),
            StatusCode = 200
        };
    }

    [HttpPost]
    public async Task<ReturnModel> Post([FromBody] MessageCreateModel messageCreateModel)
    {
        var message = _mapper.Map<Message>(messageCreateModel);
        var messageResult = await _messageService.AddAsync(message);
        return new ReturnModel
        {
            Success = true,
            Message = "Message added successfully",
            Data = _mapper.Map<MessageModel>(messageResult),
            StatusCode = 200
        };
    }

    [HttpPut]
    public async Task<ReturnModel> Put([FromBody] MessageUpdateModel messageUpdateModel)
    {
        var message = _mapper.Map<Message>(messageUpdateModel);
        var messageResult = await _messageService.UpdateAsync(message);
        return new ReturnModel
        {
            Success = true,
            Message = "Message updated successfully",
            Data = _mapper.Map<MessageModel>(messageResult),
            StatusCode = 200
        };
    }

    [HttpDelete("{id}")]
    public async Task<ReturnModel> Delete(int id)
    {
        var message = await _messageService.GetByIdAsync(id);
        await _messageService.DeleteAsync(message);
        return new ReturnModel
        {
            Success = true,
            Message = "Message deleted successfully",
            StatusCode = 200
        };
    }
}
