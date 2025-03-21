using FoodRescue.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {

            builder.HasData
                (
                new List<IdentityRole<Guid>>
                {
                    new IdentityRole<Guid>
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Admin",
                        NormalizedName ="ADMIN",
                        ConcurrencyStamp = "00000000-0000-0000-0000-000000000006"
                    },
                    new IdentityRole<Guid>
                    {
                        Id= Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Charity",
                        NormalizedName ="CHARITY",
                        ConcurrencyStamp ="00000000-0000-0000-0000-000000000007"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Donor",
                        NormalizedName ="DONOR",
                        ConcurrencyStamp = "00000000-0000-0000-0000-000000000008"
                    }


                }

                );
        }
    }
}
