using MyWebAPI.Models;
using MyWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    public interface IUserRepository
    {
        public User getUser(Guid UserId);
        public void addNewUser(User usuario);

        public IEnumerable<User> getUsers();

        public User getUserByLogin(string login);

        public bool alreadyExists(UserDto userDto);
    }
}
