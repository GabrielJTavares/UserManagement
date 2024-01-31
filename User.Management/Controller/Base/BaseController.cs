using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Message.Response;

namespace UserManagement.Controller.Base
{
    public class BaseController : ControllerBase
    {
        public IActionResult AddStatusCode(BaseResponse response)
        {
            if (response == null)
                throw new NullReferenceException("Resposta nula!");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return base.NoContent();

            return base.StatusCode((int)response.StatusCode,response);

        }
    }
}
