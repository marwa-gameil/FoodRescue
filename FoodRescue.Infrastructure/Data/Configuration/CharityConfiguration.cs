using FoodRescue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRescue.Infrastructure.Data.Configuration
{
    public class CharityConfiguration : IEntityTypeConfiguration<Charity>
    {
        public void Configure(EntityTypeBuilder<Charity> builder)
        {
            builder.HasOne(c => c.User)
                  .WithOne()
                  .HasForeignKey<Charity>(c => c.UserId);

            // builder.HasData(
            //      new List<Charity>
            //  {
            //     new Charity(Guid.Parse("00000000-0000-0000-0000-000000000004"))
            //     {
                   
            //         UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            //         IsVerfied = true,
            //         VerificationDocument = "doc1.pdf"
            //     },
            //     new Charity(Guid.Parse("00000000-0000-0000-0000-000000000005"))
            //     {

            //         UserId =Guid.Parse("00000000-0000-0000-0000-000000000003"),
            //         IsVerfied = false,
            //         VerificationDocument = "doc2.pdf"
            //     }
            //  }
            //  );
        }

    }
}
