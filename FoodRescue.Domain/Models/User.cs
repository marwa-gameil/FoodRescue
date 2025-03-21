using Microsoft.AspNetCore.Identity;
using FoodRescue.Domain.Abstractions;


namespace FoodRescue.Domain.Models
{
    public class User : IdentityUser<Guid>
    {

        public string? Name { get; set; }


        public string? Address { get; set; }


    }
    
}
