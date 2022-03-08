using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Data;
using MyWebAPI.Models.DTOs;
using MyWebAPI.Settings.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    /// <summary>
    /// Teste pra ver onde esse trem vai aparecer
    /// </summary>
    [ApiController]
    [Route("login")]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public AuthController(UserRepository repository)
        {
            _userRepository = repository;
        }

        /// <summary>
        /// Endpoint to authenticate user
        /// </summary>
        [HttpPost]
        public ActionResult AuthUser([FromBody] UserLogin userLogin)
        {

            if (!_userRepository.getUsers().Any(userDb => userDb.Email == userLogin.Email))
                return BadRequest("This email doesn't existis in our database");
            
            var userDb = _userRepository.getUsers().FirstOrDefault(userDb => userDb.Email == userLogin.Email);
            
            if (!BCrypt.Net.BCrypt.Verify(userLogin.Password, userDb.Password))
                return BadRequest("Invalid password");

            var token = TokenService.GenerateToken(userDb);
            
            return Ok(token);
        }

        

    }
}
