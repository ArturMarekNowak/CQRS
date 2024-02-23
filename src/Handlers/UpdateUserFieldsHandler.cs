using Cqrs.Database.Contexts;
using Cqrs.Models;
using Cqrs.Models.Queries;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace Cqrs.Handlers;

public class UpdateUserFieldsHandler : IRequestHandler<UpdateUserFieldsWithIdCommand, UpdateUserResponse>
{
    private readonly UsersReadWriteDbContext _usersReadWriteDbContext;

    public UpdateUserFieldsHandler(UsersReadWriteDbContext usersReadWriteDbContext)
    {
        _usersReadWriteDbContext = usersReadWriteDbContext;
    }
    
    public async Task<UpdateUserResponse> Handle(UpdateUserFieldsWithIdCommand command, CancellationToken cancellationToken)
    {
        var user = _usersReadWriteDbContext.Users.FirstOrDefault(u => u.Id == command.Id);

        if (user is null)
            return new UpdateUserResponse(null);

        user = new User(command);

        await _usersReadWriteDbContext.SaveChangesAsync(cancellationToken);

        return new UpdateUserResponse(user);
    }
}