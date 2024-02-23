using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Queries;

public sealed record UpdateUserCommand(int Id, CreateOrUpdateUserCommand CreateOrUpdateUserCommand) : IRequest<UpdateUserResponse>;