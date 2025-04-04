using FoodRescue.Application.DTOs;
using FoodRescue.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Mappers
{
    public static class UserMapper
    {
        public static User ToUserModel(this RegisterDto userDTO) =>
         new User
         {
             Name = userDTO.Name,
             UserName = userDTO.Email,
             Email = userDTO.Email,
             Address = userDTO.Address
            
         };
        public static UserDTO ToUserDTO(this User user) =>
            new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email!,
                Address = user.Address
                
            };
    }
}
