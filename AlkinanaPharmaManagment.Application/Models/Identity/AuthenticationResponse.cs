﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Models.Identity
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; } // Added
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; } // Optional: إضافة تاريخ الانتهاء
    }
}
