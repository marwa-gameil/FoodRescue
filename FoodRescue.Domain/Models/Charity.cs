using FoodRescue.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRescue.Domain.Models
{
    public class Charity : BaseModel
    {
        public Charity(Guid id)
        {
            Id = id;
        }
        public Charity()
        {
            
        }
        public Guid UserId { get; set; }
        public bool IsVerfied { get; set; }
        public string VerificationDocument { get; set; }

        public User User { get; set; }


       
       
        
    }
}
