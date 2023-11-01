using Cqrs.Models.Requests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cqrs.Models;

public sealed class User
{
    public User(CreateUserRequest createUserRequest)
    {
        Name = createUserRequest.Name;
        Surname = createUserRequest.Surname;
        Email = createUserRequest.Email;
    }
    
    public User(UpdateUserRequest updateUserRequest)
    {
        Id = updateUserRequest.Id;
        Name = updateUserRequest.User.Name;
        Surname = updateUserRequest.User.Surname;
        Email = updateUserRequest.User.Email;
    }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
}