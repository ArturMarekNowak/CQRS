using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Queries;

public sealed record UpdateUserFieldsCommand(string? Name, string? Surname, string? Email) : IRequest<UpdateUserFieldsResponse>;