namespace Cqrs.Models.CreateUserRequest;

public sealed record CreateUserRequest(string Name, string Surname, string Email);