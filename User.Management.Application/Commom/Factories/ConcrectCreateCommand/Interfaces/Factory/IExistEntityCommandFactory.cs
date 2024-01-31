using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.EnumCommand;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Interfaces.ExistEntity;

namespace UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Interfaces.Factory
{
    public interface IExistEntityCommandFactory
    {
        IExistEntityCommand GetCommand(EnumEntity type);
    }
}
