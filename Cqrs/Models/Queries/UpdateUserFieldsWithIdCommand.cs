using System.Text.Json.Serialization;
using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Models.Queries;

public sealed class UpdateUserFieldsWithIdCommand : IRequest<UpdateUserResponse>
{
    public UpdateUserFieldsWithIdCommand(string id, UpdateUserFieldsCommand updateUserFieldsCommand)
    {
        Id = id;
        Name = updateUserFieldsCommand.Name;
        Surname = updateUserFieldsCommand.Surname;
        Email = updateUserFieldsCommand.Email;
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