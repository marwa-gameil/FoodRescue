using FoodRescue.Application.DTOs;
using FoodRescue.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodRescue.API.Controllers
{
   
    public class UsersController :ApiBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) =>
            _userService = userService;
          


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(Guid id) =>
            HandleResult(await _userService.GetByIdAsync(id));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll() =>
            HandleResult(await _userService.GetAll());

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) =>
            HandleResult(await _userService.DeleteAsync(id));

    }
}
