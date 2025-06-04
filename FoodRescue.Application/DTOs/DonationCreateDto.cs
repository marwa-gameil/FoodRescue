using FoodRescue.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.DTOs
{
    public class DonationCreateDto
    {
        [Required]
        public required string FoodType { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime PickupTime { get; set; }
        [Required]
        public Guid CharityId { get; set; }
        // [Required]
        // public Guid DonorId { get; set; }
        [Required]
        public required string Location { get; set; }

    }
}
