using System.Text.Json.Serialization;
using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Requests;

public sealed class UpdateUserFieldsWithIdRequest : IRequest<UpdateUserResponse>
{
    public UpdateUserFieldsWithIdRequest(string id, UpdateUserFieldsRequest updateUserFieldsRequest)
    {
        Id = id;
        Name = updateUserFieldsRequest.Name;
        Surname = updateUserFieldsRequest.Surname;
        Email = updateUserFieldsRequest.Email;
    }

    [JsonIgnore]
    public string Id { get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Surname { get; } 
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Email { get; }
}