using Cqrs.Database.Contexts;
using Cqrs.Models.Commands;
using Cqrs.Models.Responses;
using MediatR;

namespace Cqrs.Handlers;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly UsersReadWriteDbContext _usersReadWriteDbContext;

    public UpdateUserHandler(UsersReadWriteDbContext usersReadWriteDbContext)
    {
        _usersReadWriteDbContext = usersReadWriteDbContext;
    }
    
    public async Task<UpdateUserResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = _usersReadWriteDbContext.Users.FirstOrDefault(u => u.Id == command.Id);

        if (user is null)
            return new UpdateUserResponse(null);

        user.UpdateNameSurnameAndEmail(command);
        await _usersReadWriteDbContext.SaveChangesAsync(cancellationToken);

        return new UpdateUserResponse(user);
    }
}