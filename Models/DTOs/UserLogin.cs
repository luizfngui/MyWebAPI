using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models.DTOs
{
    public class UserLogin
    {
        /// <example>
        /// ryan@reynolds.com
        /// </example>
        [Required(ErrorMessage ="The field 'Email' is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The field 'Password' is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
