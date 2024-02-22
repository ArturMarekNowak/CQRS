using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Commands;

public sealed record GetUserQuery(string Id) : IRequest<GetUserResponse>;