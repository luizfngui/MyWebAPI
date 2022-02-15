using AutoMapper;
using MyWebAPI.Models;
using MyWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(des => des.CreatedAt, map => map.MapFrom(_ => DateTime.Now));

            CreateMap<User, UserView>();
        }
    }
}
