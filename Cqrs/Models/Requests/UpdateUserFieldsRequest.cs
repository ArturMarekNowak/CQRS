using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Requests;

public sealed record UpdateUserFieldsRequest(string? Name, string? Surname, string? Email) : IRequest<UpdateUserFieldsResponse>;