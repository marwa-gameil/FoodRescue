using FoodRescue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Interfaces
{
    public interface ICurrentLoggedInUser
    {
        string UserId { get; }
        Task<User> GetUser();
    }
}
