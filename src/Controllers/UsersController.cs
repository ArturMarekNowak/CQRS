using Cqrs.Models.Commands;
using Cqrs.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers;

[ApiController]
public sealed class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var request = new GetAllUsersQuery();
        var response = await _mediator.Send(request);
        
        return Ok(response.Users);
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var request = new GetUserQuery(id);
        var response = await _mediator.Send(request);

        return response.User is null ? NotFound() : Ok(response.User);
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUserAsync(CreateOrUpdateUserCommand user)
    {
        var response = await _mediator.Send(user);
        
        return Ok(response.Id);
    }
    
    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, CreateOrUpdateUserCommand user)
    {
        var request = new UpdateUserCommand(id, user);
        var response = await _mediator.Send(request);
        
        return response.User is null ? NotFound() : Ok(response.User);
    }
    
    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var request = new DeleteUserCommand(id); 
        var response = await _mediator.Send(request);

        return response.User is null ? NotFound() : Ok(response.User);
    }
}