using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodRescue.Domain.Models;

namespace FoodRescue.Infrastructure.Data;

public sealed class ApplicationDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<Donation>()
        .HasOne(d => d.Charity)              // Assuming Charity is a navigation property
        .WithMany(c => c.DonationsReceived)          // Assuming Donations is a collection in Charity
        .HasForeignKey(d => d.CharityId)     // The foreign key column
        .OnDelete(DeleteBehavior.Restrict);
    }
}
