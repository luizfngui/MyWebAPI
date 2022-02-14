using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Data;
using MyWebAPI.Models;
using MyWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;
        public UserController(UserContext context)
        {
            _userContext = context;
        }
        [HttpPost]
        public ActionResult AddUser([FromBody] UserDto userDto)
        {
            User user = new User(userDto.Name, userDto.Email, userDto.Password);


            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            Console.WriteLine("teste");
            return CreatedAtAction("AddUser", user);
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> getUsers()
        {
            return Ok(_userContext.Users);
        }
    }
}
