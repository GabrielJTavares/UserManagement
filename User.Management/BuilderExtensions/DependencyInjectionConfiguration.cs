using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand;
using UserManagement.Application.Commom.Factories.ConcrectCreateCommand.Interfaces.ExistEntity;
using UserManagement.Application.Context.UserContext.Interfaces.Repository;
using UserManagement.Infra.Shared;
using UserManagement.Infra.UserContext;

namespace UserManagement.BuilderExtensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IFunctionsHostBuilder ConfigureDependencyInjection(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<SqlFactory>();

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IReadUserRepository, ReadUserRepository>();

            builder.Services.AddTransient<IExistEntityCommand, UserFactory>();

            return builder;
        }
    }
}
