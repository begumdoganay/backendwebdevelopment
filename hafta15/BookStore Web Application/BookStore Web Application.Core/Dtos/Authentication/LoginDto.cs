﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Dtos.Authentication
{
    public class LoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
