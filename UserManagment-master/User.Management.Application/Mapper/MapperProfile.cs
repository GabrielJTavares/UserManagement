using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Context.UserContext.Command;
using UserManagement.Application.Mapper.Convert;
using UserManagement.Domain.UserContext.Entities;

namespace UserManagement.Application.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserCommand, User>().ConvertUsing<CreateUserConvert>();
        }

    }
}
