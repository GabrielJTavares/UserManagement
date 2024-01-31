using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Commom.ResponseBody
{
    internal static class TextResponseBody
    {
        public static string NotFoundEntity(string Entity) => $"Não localizado [{Entity}].";
        public static string InternalServerError => $"Entre em contato com o administrador do sistema.";
    }
}
