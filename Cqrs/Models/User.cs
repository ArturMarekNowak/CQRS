using Cqrs.Models.Requests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cqrs.Models;

public sealed class User
{
    public User(CreateOrUpdateUserRequest createOrUpdateUserRequest)
    {
        Name = createOrUpdateUserRequest.Name;
        Surname = createOrUpdateUserRequest.Surname;
        Email = createOrUpdateUserRequest.Email;
    }
    
    public User(UpdateUserRequest updateUserRequest)
    {
        Id = updateUserRequest.Id;
        Name = updateUserRequest.CreateOrUpdateUserRequest.Name;
        Surname = updateUserRequest.CreateOrUpdateUserRequest.Surname;
        Email = updateUserRequest.CreateOrUpdateUserRequest.Email;
    }

    public User(UpdateUserFieldsWithIdRequest updateUserFieldsWithIdRequest)
    {
        Id = updateUserFieldsWithIdRequest.Id;
        Name = updateUserFieldsWithIdRequest.Name;
        Surname = updateUserFieldsWithIdRequest.Surname;
        Email = updateUserFieldsWithIdRequest.Email;
    }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
}