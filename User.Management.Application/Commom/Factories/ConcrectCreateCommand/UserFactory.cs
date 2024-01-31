using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.EnumCommand;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Interfaces.ExistEntity;
using UserManagement.Application.Commom.Message.Response;
using UserManagement.Application.Commom.ResponseBody;
using UserManagement.Application.Context.UserContext.Interfaces.Repository;

namespace UserManagement.Application.Commom.Factories.ConcrectCreateCommand
{
    public class UserFactory : IExistEntityCommand
    {
        private readonly IReadUserRepository _readUserRepository;

        public UserFactory(IReadUserRepository readUserRepository)
        {
            _readUserRepository = readUserRepository;
        }

        public EnumEntity GetCommand()
        {
            return EnumEntity.User;
        }

        public async Task<BaseResponse> PosCommandAsync(Guid id)
        {
            if (id != Guid.Empty && await _readUserRepository.IsExist(id))
                return new BaseResponse(System.Net.HttpStatusCode.OK);

            return new BaseResponse(System.Net.HttpStatusCode.NoContent, TextResponseBody.NotFoundEntity("USER"));
        }
    }
}
