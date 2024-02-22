using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Queries;

public sealed record UpdateUserCommand(string Id, CreateOrUpdateUserCommand CreateOrUpdateUserCommand) : IRequest<UpdateUserResponse>;