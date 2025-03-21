using FoodRescue.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace FoodRescue.Domain.Models
{
    public class Donation  : BaseModel
    {
        public Donation(Guid id)
        {
            Id = id;
        }

        public string FoodType { get; set; }
        public int Quantity { get; set; }
        public DateTime PickupTime { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }

        public Guid UserId { get; set; } // foreign key
        public User? Doner { get; set; } // navigaton property

        public Guid CharityId { get; set; } // foreign key
        public Charity? Charity { get; set; } // navigation property

       
    }
}
