using Cqrs.Models;
using Cqrs.Models.Requests;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Handlers;

public sealed class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IMongoCollection<User> _usersCollection;

    public GetUserHandler(IOptions<DatabasesConfiguration> databaseConfiguration)
    {
        var mongoClient = new MongoClient(databaseConfiguration.Value.UsersDb!.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.Value.UsersDb.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(databaseConfiguration.Value.UsersDb.CollectionName);
    }
    
    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersCollection
            .Find(u => u.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        return new GetUserResponse(user);
    }
}