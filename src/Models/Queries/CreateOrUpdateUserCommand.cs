using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Queries;

public sealed record CreateOrUpdateUserCommand(string Name, string Surname, string Email) : IRequest<CreateUserResponse>;