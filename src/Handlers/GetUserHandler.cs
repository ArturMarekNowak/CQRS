using Cqrs.Database.Contexts;
using Cqrs.Models.Queries;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

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