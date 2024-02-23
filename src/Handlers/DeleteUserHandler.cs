using Cqrs.Database.Contexts;
using Cqrs.Models.Queries;
using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Handlers;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly UsersReadWriteDbContext _usersReadWriteDbContext;

    public DeleteUserHandler(UsersReadWriteDbContext usersReadWriteDbContext)
    {
        _usersReadWriteDbContext = usersReadWriteDbContext;
    }
    
    public async Task<DeleteUserResponse> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var userToDelete = _usersReadWriteDbContext.Users.FirstOrDefault(u => u.Id!.Value == command.Id);
        
        if(userToDelete is null)
            return new DeleteUserResponse(null);
        
        var deletedUser = _usersReadWriteDbContext.Users.Remove(userToDelete);
        await _usersReadWriteDbContext.SaveChangesAsync(cancellationToken);
        
        return new DeleteUserResponse(deletedUser.Entity);
    }
}