using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodRescue.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodRescue.Infrastructure.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly UserManager<User> _userManager;

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new List<User>
            {
                new User
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000001",
                    Name = "Alice Johnson",
                    Email = "alice@example.com",
                    PhoneNumber = "123456789",
                    Address = "New York"
                },
                new User
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000002",
                    Name = "Bob Smith",
                    Email = "bob@example.com",
                    PhoneNumber = "987654321",
                    Address = "California"
                },
                new User
                {

                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000003",
                    Name = "Michel Jakson",
                    Email = "michel@example.com",
                    PhoneNumber = "555123456",
                    Address = "Los Angeles"
                },
                new User
                {

                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000004",
                    Name = "Papa Jones",
                    Email = "papa@example.com",
                    PhoneNumber = "442123456",
                    Address = "Canada"
                },
                new User
                {

                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000005",
                    Name = "Pizza hut",
                    Email = "pizzahut@example.com",
                    PhoneNumber = "44553456",
                    Address = "Canada"
                },

            }
        );
            

    }
}
