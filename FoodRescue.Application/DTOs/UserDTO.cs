using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.DTOs
{
    public record UserDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }

        public bool IsCharity { get; set; } = false;
    }
}
