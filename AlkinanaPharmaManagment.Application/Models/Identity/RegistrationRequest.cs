using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PharmaName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        
        public string? ConfirmPassword { get; set; } 
    }
}
