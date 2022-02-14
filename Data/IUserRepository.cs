using MyWebAPI.Models;
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
    }
}
