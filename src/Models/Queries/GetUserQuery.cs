using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Queries;

public sealed record GetUserQuery(int Id) : IRequest<GetUserResponse>;