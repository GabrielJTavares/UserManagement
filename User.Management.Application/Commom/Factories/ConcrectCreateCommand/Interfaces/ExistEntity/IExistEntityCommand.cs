using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.EnumCommand;
using UserManagement.Application.Commom.Message.Response;

namespace UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Interfaces.ExistEntity
{
    public interface IExistEntityCommand
    {
        EnumEntity GetCommand();
        Task<BaseResponse> PosCommandAsync(Guid Id);
    }
}
