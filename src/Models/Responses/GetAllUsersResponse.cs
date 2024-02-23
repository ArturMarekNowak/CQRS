namespace Cqrs.Models.Responses;

public sealed record GetAllUsersResponse(IEnumerable<User> Users);