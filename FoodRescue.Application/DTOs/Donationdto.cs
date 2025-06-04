using FoodRescue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.DTOs
{
    public class Donationdto
    {
        public Guid Id { get; set; }
        public required string FoodType { get; set; }
        public int Quantity { get; set; }
        public DateTime PickupTime { get; set; }
        public required string Status { get; set; }
        public required string Location { get; set; }

        public Guid DonorId { get; set; } // foreign key
        public required string DonerName { get; set; } // navigaton property

        public Guid CharityId { get; set; } // foreign key
        public required string CharityName { get; set; } // navigation property

    }
}
