using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Commands;

public sealed record CreateOrUpdateUserCommand(string Name, string Surname, string Email) : IRequest<CreateUserResponse>;