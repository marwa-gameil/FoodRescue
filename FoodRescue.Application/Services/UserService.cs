using FoodRescue.Application.DTOs;
using FoodRescue.Application.Interfaces;
using FoodRescue.Application.Mappers;
using FoodRescue.Application.Utilities;
using FoodRescue.Domain.Models;
using FoodRescue.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodRescue.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _manager;

        public UserService(UserManager<User> manager)
        {
            _manager = manager;
        }
        public async Task<Result<UserDTO>> GetByIdAsync(Guid id)
        {
            User? user = await _manager.FindByIdAsync(id.ToString());
            return user switch
            {
                null => Result.Fail<UserDTO>(AppResponses.NotFoundResponse(id, nameof(User))),
                _ => Result.Success(user.ToUserDTO())
            };
        }
        public async Task<Result<IEnumerable<UserDTO>>> GetAll()
        {
            IEnumerable <User> users = await _manager.Users.ToListAsync();
           return Result.Success(users.ConvertAll(UserMapper.ToUserDTO));
        }


        public async Task<Result> DeleteAsync(Guid id)
        {
            User? user = await _manager.FindByIdAsync(id.ToString());
            if (user is null) return Result.Fail(AppResponses.NotFoundResponse(id, nameof(User)));
            await _manager.DeleteAsync(user);
            return Result.Success(StatusCodes.Status204NoContent);
        }


    }
}
