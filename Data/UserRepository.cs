using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using MyWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    public class UserRepository : DbContext, IUserRepository
    {
        public UserRepository(DbContextOptions<UserRepository> options ): base (options) 
        {

        }

        public DbSet<User> Users { get; set; }

        public void addNewUser(User usuario)
        {
            Users.Add(usuario);
        }

        public bool alreadyExists(UserDto userDto)
        {
            return (Users.Any(x => x.Login == userDto.Login));
        }

        public User getUser(Guid UserId)
        {
            return Users.FirstOrDefault(x => x.Id == UserId);
        }

        public User getUserByLogin(string login)
        {
            return Users.FirstOrDefault(x => x.Login == login);
        }

        public IEnumerable<User> getUsers()
        {
            return Users.AsEnumerable<User>();
        }
    }
}
