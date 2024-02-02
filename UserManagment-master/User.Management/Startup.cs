using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.BuilderExtensions;

[assembly: FunctionsStartup(typeof(UserManagement.Startup))]
namespace UserManagement
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.ConfigureDependencyInjection();
            builder.ConfigureMediatr();
            builder.ConfigureAutoMapeer();
        }
    }
}
