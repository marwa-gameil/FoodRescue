using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.DTOs
{
    public record CharityDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsVerfied { get; set; }
        public string VerificationDocumentURL { get; set; }
        public string UserName { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }


    }
}
