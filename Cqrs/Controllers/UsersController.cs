using Cqrs.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers;

[ApiController]
public sealed class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMediator _mediator;

    public UsersController(ILogger<UsersController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var request = new GetAllUsersRequest();
        var response = await _mediator.Send(request);
        
        return Ok(response.Users);
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUserAsync(string id)
    {
        var request = new GetUserRequest(id);
        var response = await _mediator.Send(request);

        return response.User is null ? NotFound() : Ok(response.User);
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUserAsync(CreateOrUpdateUserRequest user)
    {
        var response = await _mediator.Send(user);
        
        return Ok(response.Id);
    }
    
    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUserAsync(string id, CreateOrUpdateUserRequest user)
    {
        var request = new UpdateUserRequest(id, user);
        var response = await _mediator.Send(request);
        
        return response.User is null ? NotFound() : Ok(response.User);
    }
    
    [HttpPatch("users/{id}")]
    public async Task<IActionResult> UpdateUserFieldsAsync(string id, UpdateUserFieldsRequest user)
    {
        var request = new UpdateUserFieldsWithIdRequest(id, user);
        var response = await _mediator.Send(request);
        
        return response.User is null ? NotFound() : Ok(response.User);
    }
    
    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUserAsync(string id)
    {
        var request = new DeleteUserRequest(id); 
        var response = await _mediator.Send(request);

        return response.User is null ? NotFound() : Ok(response.User);
    }
}