using Cqrs.Models;
using Cqrs.Models.Requests;
using Cqrs.Models.Responses;
using Cqrs.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Services;

public sealed class UsersService : IUsersService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UsersService(IOptions<DatabasesConfiguration> databaseConfiguration)
    {
        var mongoClient = new MongoClient(databaseConfiguration.Value.UsersDb!.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.Value.UsersDb.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(databaseConfiguration.Value.UsersDb.CollectionName);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _usersCollection.Find(_ => true).ToListAsync();
    }

    public async Task<User> GetUserAsync(string id)
    {
        return await _usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest user)
    {
        var newUser = new User(user);
        
        await _usersCollection.InsertOneAsync(newUser);

        return new CreateUserResponse(newUser.Id!);
    }

    public async Task<User> UpdateUserAsync(string id, CreateUserRequest user)
    {
        var updatedUser = new User(id, user);
        
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        return updatedUser;
    }

    public async Task DeleteUserAsync(string id)
    {
        await _usersCollection.DeleteOneAsync(x => x.Id == id);
    }
}