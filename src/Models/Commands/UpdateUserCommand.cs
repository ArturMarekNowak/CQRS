using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Commands;

public sealed record UpdateUserCommand(int Id, CreateOrUpdateUserCommand CreateOrUpdateUserCommand) : IRequest<UpdateUserResponse>;