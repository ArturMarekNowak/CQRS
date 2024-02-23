using Cqrs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cqrs.Database;

public sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.Property<int?>("Id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property<string>("Email")
            .HasColumnType("text");

        builder.Property<string>("Name")
            .HasColumnType("text");

        builder.Property<string>("Surname")
            .HasColumnType("text");

        builder.HasKey("Id");
    }
}