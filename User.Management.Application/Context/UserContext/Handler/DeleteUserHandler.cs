using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Message.Response;
using UserManagement.Application.Commom.ResponseBody;
using UserManagement.Application.Context.UserContext.Command;
using UserManagement.Application.Context.UserContext.Interfaces.Repository;

namespace UserManagement.Application.Context.UserContext.Handler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IReadUserRepository _repositoryRead;

        public DeleteUserHandler(IUserRepository repository, IReadUserRepository repositoryRead)
        {
            _repository = repository;
            _repositoryRead = repositoryRead;
        }

        public async Task<BaseResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryRead.GetById(request.Id);
            if (entity == null)
                return await Task.FromResult(new BaseResponse(HttpStatusCode.NotFound, TextResponseBody.NotFoundEntity("[USER]")));

            entity.Inactivate();

            var validate = entity.Validate();
            if (!validate.IsValid)
                return await Task.FromResult(new BaseResponse(HttpStatusCode.BadRequest, validate.Errors));

            if (await _repository.Delete(entity))
                return await Task.FromResult(new BaseResponse(HttpStatusCode.NoContent));

            return await Task.FromResult(new BaseResponse(HttpStatusCode.InternalServerError, TextResponseBody.InternalServerError));
        }
    }
}
