using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Message.Response;
using UserManagement.Application.Commom.ResponseBody;
using UserManagement.Application.Context.UserContext.Command;
using UserManagement.Application.Context.UserContext.Interfaces.Repository;

namespace UserManagement.Application.Context.UserContext.Handler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IReadUserRepository _readUserRepository;

        public UpdateUserHandler(IUserRepository userRepository, IReadUserRepository readUserRepository)
        {
            _userRepository = userRepository;
            _readUserRepository = readUserRepository;
        }

        public async Task<BaseResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readUserRepository.GetById(request.Id);
            if (entity == null)
                return await Task.FromResult(new BaseResponse(HttpStatusCode.NotFound, TextResponseBody.NotFoundEntity("[USER]")));

            entity.Update(request.Name, request.DocumentNumber, request.Email, request.Password);


            var validate = entity.Validate();

            if (!validate.IsValid)
                return await Task.FromResult(new BaseResponse(HttpStatusCode.BadRequest, validate.Errors));

            if (await _userRepository.Update(entity))
                return await Task.FromResult(new BaseResponse(HttpStatusCode.OK, entity));

            return await Task.FromResult(new BaseResponse(HttpStatusCode.InternalServerError, TextResponseBody.InternalServerError));

          
        }
    }
}
