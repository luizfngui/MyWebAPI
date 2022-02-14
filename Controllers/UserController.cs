using AutoMapper;
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
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public UserController(UserRepository context, IMapper mapper)
        {
            _userRepository = context;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult AddUser([FromBody] UserDto userDto)
        {
            
            User user = _mapper.Map<User>(userDto);
            _userRepository.addNewUser(user);
            _userRepository.SaveChanges();
            return CreatedAtAction("AddUser", user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> getUsers()
        {
            return Ok(_userRepository.Users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> getUserById(Guid id) 
        {
            return _userRepository.getUser(id);
        }


    }
}
