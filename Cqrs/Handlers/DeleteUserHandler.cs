using Cqrs.Models;
using Cqrs.Models.Requests;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Handlers;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IMongoCollection<User> _usersCollection;

    public DeleteUserHandler(IOptions<DatabasesConfiguration> databaseConfiguration)
    {
        var mongoClient = new MongoClient(databaseConfiguration.Value.UsersDb!.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.Value.UsersDb.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(databaseConfiguration.Value.UsersDb.CollectionName);
    }
    
    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var deletedUser = await _usersCollection.FindOneAndDeleteAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return new DeleteUserResponse(deletedUser);
    }
}