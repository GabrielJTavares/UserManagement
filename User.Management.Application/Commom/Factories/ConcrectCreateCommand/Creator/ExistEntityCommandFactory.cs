using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.EnumCommand;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Interfaces.ExistEntity;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Interfaces.Factory;

namespace UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Creator
{
    public class ExistEntityCommandFactory : IExistEntityCommandFactory
    {

        public IEnumerable<IExistEntityCommand> _existEntityCommand;

        public ExistEntityCommandFactory(IEnumerable<IExistEntityCommand> existEntityCommand)
        {
            _existEntityCommand = existEntityCommand;
        }

        public IExistEntityCommand GetCommand(EnumEntity type) => _existEntityCommand.First(x => x.GetCommand() == type);
    }
}
