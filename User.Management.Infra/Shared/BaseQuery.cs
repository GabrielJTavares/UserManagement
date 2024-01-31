using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infra.Shared
{
    internal abstract class BaseQuery
    {
        public string? Table { get; set; }
        public string? InnerTable { get; set; }
        public string? Query { get; set; }
        public object? Parameter { get; set; }
    }
}
