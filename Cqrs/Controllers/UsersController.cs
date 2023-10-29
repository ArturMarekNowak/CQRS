using Cqrs.Models.CreateUserRequest;
using Cqrs.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers;

[ApiController]
[Route("users")]
public sealed class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUsersService _usersService;

    public UsersController(ILogger<UsersController> logger,
        IUsersService usersService)
    {
        _logger = logger;
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _usersService.GetAllUsersAsync();
        
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(string id)
    {
        var users = await _usersService.GetUserAsync(id);
        
        return Ok(users);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(CreateUserRequest user)
    {
        var createUserResponse = await _usersService.CreateUserAsync(user);
        
        return Ok(createUserResponse);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync(string id, CreateUserRequest user)
    {
        var users = await _usersService.UpdateUserAsync(id, user);
        
        return Ok(users);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(string id)
    {
        await _usersService.DeleteUserAsync(id);
        
        return NoContent();
    }
}