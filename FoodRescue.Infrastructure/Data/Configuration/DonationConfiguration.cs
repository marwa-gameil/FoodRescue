using FoodRescue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRescue.Infrastructure.Data.Configuration
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
       
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasOne(c => c.Charity)
                .WithMany()
                .HasForeignKey(c => c.CharityId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Doner)
             .WithMany()
             .HasForeignKey(c => c.UserId);
            /*
            builder.HasData(

            new List<Donation>
            {

                 new Donation (Guid.Parse("00000000-0000-0000-0000-000000000006")){

                    
                     FoodType = "Canned Goods",
                     Quantity = 20,
                     PickupTime =new DateTime(2025, 3, 22, 15, 19, 24, 242, DateTimeKind.Utc),
                     Status = "Pending",
                     Location = "NY Warehouse",
                     UserId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                     CharityId =Guid.Parse("00000000-0000-0000-0000-000000000002")
                 },
                new Donation (Guid.Parse("00000000-0000-0000-0000-000000000007")) {
                    
                    FoodType = "Fresh Vegetables",
                    Quantity = 50,
                    PickupTime =new DateTime(2025, 3, 23, 15, 19, 24, 242, DateTimeKind.Utc),
                    Status = "Approved",
                    Location = "CA Storage",
                    UserId=Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    CharityId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                }
            }
            );*/
        }
    }
}
