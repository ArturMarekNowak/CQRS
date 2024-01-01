using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Requests;

public sealed record UpdateUserRequest(string Id, CreateOrUpdateUserRequest CreateOrUpdateUserRequest) : IRequest<UpdateUserResponse>;