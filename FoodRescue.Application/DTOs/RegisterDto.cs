using FoodRescue.Application.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.DTOs
{
    public class RegisterDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Address { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        [Required]
        public bool IsCharity { get; set; }

        [VerificationDocRequired]
        public IFormFile? VerificationDoc { get; set; }
    }
}
