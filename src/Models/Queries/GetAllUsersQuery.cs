using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Queries;

public sealed record GetAllUsersQuery : IRequest<GetAllUsersResponse>;