using Cqrs.Database.Contexts;
using Cqrs.Models.Queries;
using Cqrs.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Handlers;

public sealed class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
{
    private readonly UsersReadOnlyDbContext _usersReadOnlyDbContext;

    public GetAllUsersHandler(UsersReadOnlyDbContext usersReadOnlyDbContext)
    {
        _usersReadOnlyDbContext = usersReadOnlyDbContext;
    }
    
    public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await _usersReadOnlyDbContext.Users.ToListAsync(cancellationToken);
        
        return new GetAllUsersResponse(users);
    }
}