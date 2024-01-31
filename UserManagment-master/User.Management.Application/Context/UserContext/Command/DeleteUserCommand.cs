using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Message.Response;

namespace UserManagement.Application.Context.UserContext.Command
{
    public class DeleteUserCommand:IRequest<BaseResponse>
    {
        public DeleteUserCommand(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
