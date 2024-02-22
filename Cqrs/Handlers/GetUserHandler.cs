using Cqrs.Database.Contexts;
using Cqrs.Models;
using Cqrs.Models.Commands;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cqrs.Handlers;

public sealed class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResponse>
{
    private readonly UsersReadOnlyDbContext _usersReadOnlyDbContext;

    public GetUserHandler(UsersReadOnlyDbContext usersReadOnlyDbContext)
    {
        _usersReadOnlyDbContext = usersReadOnlyDbContext;
    }
    
    public async Task<GetUserResponse> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _usersReadOnlyDbContext.Users.FirstOrDefaultAsync(u => u.Id == query.Id, cancellationToken: cancellationToken);
        
        return new GetUserResponse(user);
    }
}