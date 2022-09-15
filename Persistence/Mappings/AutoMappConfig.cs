using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetAllUsers;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappings
{
    public class AutoMappConfig : Profile
    {
        public AutoMappConfig()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, GetAllUserViewModel>().ReverseMap();
        }
    }
}
