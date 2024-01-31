using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infra.Shared
{
    public class SqlFactory
    {
        public SqlConnection SqlConnection()
        {
            return new SqlConnection("Server=meuregistro-br-imp-br.database.windows.net;Database=DB_UNICORH_GED;User ID=meuregistro;Password=UnicoRH@999;MultipleActiveResultSets=True");
        }
    }
}
