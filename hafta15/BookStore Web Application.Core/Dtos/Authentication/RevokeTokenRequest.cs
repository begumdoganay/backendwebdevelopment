﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Dtos.Authentication
{
    public class RevokeTokenRequest
    {
        public string? RefreshToken { get; set; }
    }
}
