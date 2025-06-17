using FoodRescue.Application.DTOs;
using FoodRescue.Domain.Models;
using FoodRescue.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Interfaces
{
    public interface ICookieAuthService
    {

        Task<Result<UserDTO>> LoginAsync(LoginDTO loginDTO);
        Task<Result> LogoutAsync();
        Task<Result<UserDTO>> RegisterAsync(RegisterDto registerDto);
    }
}
