using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Requests;

public sealed record CreateOrUpdateUserRequest(string Name, string Surname, string Email) : IRequest<CreateUserResponse>;