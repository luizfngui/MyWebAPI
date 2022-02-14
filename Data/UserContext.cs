using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options ): base (options) 
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
