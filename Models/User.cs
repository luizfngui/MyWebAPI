using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class User
    {
        public User(string name, string email, string password)
        {
            Email = email;
            Name = name;
            Password = password;
            Id = new Guid();

        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
