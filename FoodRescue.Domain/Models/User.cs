using Microsoft.AspNetCore.Identity;
using FoodRescue.Domain.Abstractions;


namespace FoodRescue.Domain.Models
{
    public class User : IdentityUser<Guid>
    {

        public required string Name { get; set; }
        public required string Address { get; set; }

       
        
        

    }
    
}
