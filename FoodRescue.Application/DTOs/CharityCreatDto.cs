using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.DTOs
{
    public record CharityCreatDto
    {
        [Required]
        public Guid UserId { get; set; }
       
        [Required]
        public required IFormFile VerificationDocument { get; set; }
        [Required]
        public required string UserName { get; set; }
    }
}
