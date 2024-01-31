using AutoMapper;
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
using UserManagement.Domain.UserContext.Entities;

namespace UserManagement.Application.Context.UserContext.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public CreateUserHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);

            var validate = entity.Validate();
            if (!validate.IsValid)
                return await Task.FromResult(new BaseResponse(HttpStatusCode.BadRequest, validate.Errors));

            if (await _repository.Create(entity))
                return await Task.FromResult(new BaseResponse(HttpStatusCode.OK, entity));

            return await Task.FromResult(new BaseResponse(HttpStatusCode.InternalServerError, TextResponseBody.InternalServerError));
        }
    }
}
