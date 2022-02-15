using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models.DTOs
{
    public class UserDto
    {
        /// <example>
        /// Ryan Reynolds
        /// </example>
        [Required(ErrorMessage ="The field 'Name' is required")]
        public string Name { get; set; }

        /// <example>
        /// ryan@reynolds.com
        /// </example>
        [Required(ErrorMessage = "The field 'Email' is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field 'Password' is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field 'Confirm Password' is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
