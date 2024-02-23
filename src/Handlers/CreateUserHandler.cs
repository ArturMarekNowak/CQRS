using Cqrs.Database.Contexts;
using Cqrs.Models;
using Cqrs.Models.Queries;
using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Handlers;

public sealed class CreateUserHandler : IRequestHandler<CreateOrUpdateUserCommand, CreateUserResponse>
{
    private readonly UsersReadWriteDbContext _usersReadWriteDbContext;

    public CreateUserHandler(UsersReadWriteDbContext usersReadWriteDbContext)
    {
        _usersReadWriteDbContext = usersReadWriteDbContext;
    }
    
    public async Task<CreateUserResponse> Handle(CreateOrUpdateUserCommand createOrUpdateUserCommand, CancellationToken cancellationToken)
    {
        var newUser = new User(createOrUpdateUserCommand);

        var user = await _usersReadWriteDbContext.Users.AddAsync(newUser, cancellationToken);
        await _usersReadWriteDbContext.SaveChangesAsync(cancellationToken);

        return new CreateUserResponse(user.Entity.Id.Value!);
    }
}