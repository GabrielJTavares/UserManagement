using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System.Reflection;
using UserManagement.Application.Context.UserContext.Handler;
using MediatR;
namespace UserManagement.BuilderExtensions
{
    public static class MediatRConfiguration
    {
        public static IFunctionsHostBuilder ConfigureMediatr(this IFunctionsHostBuilder builder)
        {

            builder.Services.AddMediatR(typeof(CreateUserHandler).GetTypeInfo().Assembly);
            builder.Services.AddMediatR(typeof(UpdateUserHandler).GetTypeInfo().Assembly);
            builder.Services.AddMediatR(typeof(DeleteUserHandler).GetTypeInfo().Assembly);

            return builder;
        }
    }
}
