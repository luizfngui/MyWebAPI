using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public UserController(UserRepository context, IMapper mapper)
        {
            _userRepository = context;
            _mapper = mapper;
        }

        ///<summary>
        /// Add a new user on the database
        ///</summary>
        [HttpPost]
        public ActionResult AddUser([FromBody] UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _userRepository.addNewUser(user);
            _userRepository.SaveChanges();
            UserView userView = _mapper.Map<UserView>(user);
            
            return CreatedAtAction("AddUser", userView);
        }

        ///<summary>
        /// Get the list of users on the DataBase
        ///</summary>
        [HttpGet]
        
        public ActionResult<IEnumerable<UserView>> getUsers()
        {
            
            return Ok(_userRepository.Users);
        }

        ///<summary>
        /// Get a user by its ID
        ///</summary>
        [HttpGet("{id}")]
        public ActionResult<UserView> getUserById(Guid id) 
        {
            if (_mapper.Map<UserView>(_userRepository.getUser(id)) is not null)
                return _mapper.Map<UserView>(_userRepository.getUser(id));

            else
                return BadRequest("User not found");

        }


    }
}
