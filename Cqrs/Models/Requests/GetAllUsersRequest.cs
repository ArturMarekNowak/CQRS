using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Requests;

public sealed record GetAllUsersRequest : IRequest<GetAllUsersResponse>;