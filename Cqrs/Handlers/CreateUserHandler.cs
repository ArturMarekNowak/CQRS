﻿using Cqrs.Models;
using Cqrs.Models.Requests;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Handlers;

public sealed class CreateUserHandler : IRequestHandler<CreateOrUpdateUserRequest, CreateUserResponse>
{
    private readonly IMongoCollection<User> _usersCollection;

    public CreateUserHandler(IOptions<DatabasesConfiguration> databaseConfiguration)
    {
        var mongoClient = new MongoClient(databaseConfiguration.Value.UsersDb!.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.Value.UsersDb.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(databaseConfiguration.Value.UsersDb.CollectionName);
    }
    
    public async Task<CreateUserResponse> Handle(CreateOrUpdateUserRequest createOrUpdateUserRequest, CancellationToken cancellationToken)
    {
        var newUser = new User(createOrUpdateUserRequest);
        
        await _usersCollection.InsertOneAsync(newUser, cancellationToken: cancellationToken);

        return new CreateUserResponse(newUser.Id!);
    }
}