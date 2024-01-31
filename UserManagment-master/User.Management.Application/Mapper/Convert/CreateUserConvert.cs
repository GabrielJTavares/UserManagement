using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Context.UserContext.Command;
using UserManagement.Domain.UserContext.Entities;

namespace UserManagement.Application.Mapper.Convert
{
    public class CreateUserConvert : ITypeConverter<CreateUserCommand, User>
    {
        public User Convert(CreateUserCommand source, User destination, ResolutionContext context)
        {
            return new User(source.Name, source.DocumentNumber, source.Email, source.Password);
        }
    }
}
