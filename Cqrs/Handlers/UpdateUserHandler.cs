using Cqrs.Models;
using Cqrs.Models.Requests;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Handlers;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private static IMongoCollection<User> _usersCollection;
    
    public UpdateUserHandler(IOptions<DatabasesConfiguration> databaseConfiguration)
    {
        var mongoClient = new MongoClient(databaseConfiguration.Value.UsersDb!.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.Value.UsersDb.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(databaseConfiguration.Value.UsersDb.CollectionName);
    }
    
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var updatedUser = new User(request);
        
        await _usersCollection.ReplaceOneAsync(x => x.Id == updatedUser.Id, updatedUser, cancellationToken: cancellationToken);

        return new UpdateUserResponse(updatedUser);
    }
}