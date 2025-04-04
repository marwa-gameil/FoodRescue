﻿using FoodRescue.Application.Interfaces;
using FoodRescue.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Utilities
{
    public class CurrentLoggedInUser : ICurrentLoggedInUser
    {
        private readonly UserManager<User> _userManager;

        public CurrentLoggedInUser(IHttpContextAccessor httpContextAccessor , UserManager<User> userManager)
        {
            UserId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            _userManager = userManager;
        }
        public string UserId { get; }

        public async Task<User> GetUser() =>
        (await _userManager.FindByIdAsync(UserId))!;
    }
}

