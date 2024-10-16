﻿using Cqrs.Models.Commands;

namespace Cqrs.Models;

public sealed class User
{
    public User()
    {
        
    }
    
    public User(CreateOrUpdateUserCommand createOrUpdateUserCommand)
    {
        Name = createOrUpdateUserCommand.Name;
        Surname = createOrUpdateUserCommand.Surname;
        Email = createOrUpdateUserCommand.Email;
    }
    
    public User(UpdateUserCommand updateUserCommand)
    {
        Id = updateUserCommand.Id;
        Name = updateUserCommand.CreateOrUpdateUserCommand.Name;
        Surname = updateUserCommand.CreateOrUpdateUserCommand.Surname;
        Email = updateUserCommand.CreateOrUpdateUserCommand.Email;
    }
    
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }

    public void UpdateNameSurnameAndEmail(UpdateUserCommand updateUserCommand)
    {
        Name = updateUserCommand.CreateOrUpdateUserCommand.Name;
        Surname = updateUserCommand.CreateOrUpdateUserCommand.Surname;
        Email = updateUserCommand.CreateOrUpdateUserCommand.Email;
    }
}