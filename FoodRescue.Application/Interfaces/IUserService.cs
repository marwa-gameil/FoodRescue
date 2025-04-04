using FoodRescue.Application.DTOs;
using FoodRescue.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserDTO>>> GetAll();
        Task<Result<UserDTO>> GetByIdAsync(Guid id);
        Task<Result> DeleteAsync(Guid id);
    }
}
