using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is mandatory.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is mandatory.")]
        [EmailAddress(ErrorMessage = "Not a valid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory.")]
        [MinLength(8, ErrorMessage = "Password is too short. (minimum 8 characters)")]
        [MaxLength(20, ErrorMessage = "Password is too long. (maximum 20 characters)")]
        public string Password { get; set; }
    }
}
