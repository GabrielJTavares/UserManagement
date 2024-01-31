using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Interfaces;
using UserManagement.Domain.UserContext.Entities;

namespace UserManagement.Application.Context.UserContext.Interfaces.Repository
{
    public interface IReadUserRepository:IReadRepository<User>
    {
    }
}
