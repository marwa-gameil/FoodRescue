﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Utilities
{
    public class CookieSetting
    {
        public double ExpireOn { get; set; } = 7;
        public bool HttpOnly { get; set; } = true;
        public bool Secure { get; set; } = true;
        public SameSiteMode SameSite { get; set; } = SameSiteMode.Lax;
        public string? AllowedOrigins { get; set; }
    }
}
