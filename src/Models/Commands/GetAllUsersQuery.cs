using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Commands;

public sealed record GetAllUsersQuery : IRequest<GetAllUsersResponse>;