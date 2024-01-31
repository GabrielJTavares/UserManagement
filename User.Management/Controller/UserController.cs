using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Context.UserContext.Interfaces.Repository;
using UserManagement.Controller.Base;
using UserManagement.Application.Context.UserContext.Command;
using UserManagement.Application.Commom.Message.Response;
using System.Net;

namespace UserManagement.Controller
{
    public class UserController:BaseController
    {
        private readonly IMediator _mediator;
        private readonly IReadUserRepository _readUserRepository;

        public UserController(IMediator mediator, IReadUserRepository readUserRepository)
        {
            _mediator = mediator;
            _readUserRepository = readUserRepository;
        }

        [FunctionName("Create")]
        public async Task<IActionResult> Create([HttpTrigger(AuthorizationLevel.Function, "post", Route = "User")] CreateUserCommand Command)
        {
            var response = await _mediator.Send(Command);
            return AddStatusCode(response);
        }

        [FunctionName("Update")]
        public async Task<IActionResult> Update([HttpTrigger(AuthorizationLevel.Function, "put", Route = "User")] UpdateUserCommand Command)
        {
            var response = await _mediator.Send(Command);
            return AddStatusCode(response);
        }

        [FunctionName("Delete")]
        public async Task<IActionResult> Delete([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "User/{Id}")] HttpRequest req, string Id)
        {
            if (!Guid.TryParse(Id, out Guid IdGuid))
                return AddStatusCode(new BaseResponse(HttpStatusCode.BadRequest));

            var response = await _mediator.Send(new DeleteUserCommand(IdGuid));
            return AddStatusCode(response);
        }

        [FunctionName("GetById")]
        public async Task<IActionResult> Get([HttpTrigger(AuthorizationLevel.Function, "get", Route = "User/{Id}")] HttpRequest req, string Id)
        {
            if (!Guid.TryParse(Id, out Guid IdGuid))
                return AddStatusCode(new BaseResponse(HttpStatusCode.BadRequest));

            var response = await _readUserRepository.GetById(IdGuid);
            return AddStatusCode(new BaseResponse(HttpStatusCode.OK, response));
        }

        [FunctionName("GetAll")]
        public async Task<IActionResult> GetAll([HttpTrigger(AuthorizationLevel.Function, "get", Route = "User")] HttpRequest req)
        {   
            var response = await _readUserRepository.GetAll();
            return AddStatusCode(new BaseResponse(HttpStatusCode.OK, response));
        }
    }
}
