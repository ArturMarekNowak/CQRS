using System.Text.Json;
using Cqrs.Models;
using Cqrs.Models.Requests;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cqrs.Handlers;

public class UpdateUserFieldsHandler : IRequestHandler<UpdateUserFieldsWithIdRequest, UpdateUserResponse>
{
    private static IMongoCollection<User>? _usersCollection;
    
    public UpdateUserFieldsHandler(IOptions<DatabasesConfiguration> databaseConfiguration)
    {
        var mongoClient = new MongoClient(databaseConfiguration.Value.UsersDb!.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.Value.UsersDb.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(databaseConfiguration.Value.UsersDb.CollectionName);
    }
    
    public Task<UpdateUserResponse> Handle(UpdateUserFieldsWithIdRequest request, CancellationToken cancellationToken)
    {
        var json = JsonSerializer.Serialize(request);
        var changesDocument = BsonDocument.Parse(json);

        UpdateDefinition<User> update = null;
        foreach (var change in changesDocument)
        {
            if (update == null)
            {
                var builder = Builders<User>.Update;
                if (change.Name == "Id") continue;
                update = builder.Set(change.Name, change.Value);
            }
            else
            {
                update = update.Set(change.Name, change.Value);
            }
        }

        update = new BsonDocumentUpdateDefinition<User>(new BsonDocument("$set", changesDocument));
        var options = new FindOneAndUpdateOptions<User>() { ReturnDocument = ReturnDocument.After };
        
        var updatedUser = _usersCollection.FindOneAndUpdate<User>(x => x.Id == request.Id, update, options);
        
        return Task.FromResult(new UpdateUserResponse(updatedUser));
    }
}