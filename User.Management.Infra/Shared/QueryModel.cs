using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infra.Shared
{
    internal class QueryModel
    {
        public QueryModel(string query, object parameters)
        {
            this.Query = query;
            this.Parameter = parameters;
        }

        public string Query { get; set; }
        public object Parameter { get; set; }
    }
}
