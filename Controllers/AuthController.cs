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

            if (!_userRepository.getUsers().Any(userDb => userDb.Login == userLogin.Login))
                return BadRequest("This login doesn't exist in our database");
            
            var userDb = _userRepository.getUsers().FirstOrDefault(userDb => userDb.Login == userLogin.Login.Trim());
            
            if (!BCrypt.Net.BCrypt.Verify(userLogin.Password, userDb.Password))
                return BadRequest("Invalid password");

            var token = TokenService.GenerateToken(userDb);
            string resposta = userDb.Name;
            return Ok(resposta);
        }

        

    }
}
