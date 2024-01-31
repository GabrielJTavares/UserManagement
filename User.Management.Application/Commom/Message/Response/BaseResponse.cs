using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Commom.Message.Response
{
    public class BaseResponse
    {
        public BaseResponse(HttpStatusCode statusCode, object? data = null)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public HttpStatusCode StatusCode { get; private set; }
        public object? Data { get; private set; }
    }
}
