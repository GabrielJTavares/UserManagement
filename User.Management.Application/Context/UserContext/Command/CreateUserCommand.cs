using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Message.Response;

namespace UserManagement.Application.Context.UserContext.Command
{
    public class CreateUserCommand : IRequest<BaseResponse>
    {
        
        public string Name { get; private set; } = string.Empty;
        public string DocumentNumber { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
    }
}
