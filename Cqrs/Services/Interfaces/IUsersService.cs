using Cqrs.Models;
using Cqrs.Models.CreateUserRequest;
using Cqrs.Models.Responses;

namespace Cqrs.Services.Interfaces;

public interface IUsersService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserAsync(string id);
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest user);
    Task<User> UpdateUserAsync(string id, CreateUserRequest user);
    Task DeleteUserAsync(string id);
}