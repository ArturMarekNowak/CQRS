using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Commands;

public sealed record DeleteUserCommand(int Id) : IRequest<DeleteUserResponse>;