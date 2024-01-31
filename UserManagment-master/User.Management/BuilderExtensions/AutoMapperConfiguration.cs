using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Application.Mapper;

namespace UserManagement.BuilderExtensions
{
    public static class AutoMapperConfiguration
    {
        public static IFunctionsHostBuilder ConfigureAutoMapeer(this IFunctionsHostBuilder hostBuilder)
        {
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            mapperConfig.AssertConfigurationIsValid();
            hostBuilder.Services.AddSingleton(mapper);

            return hostBuilder;
        }
    }
}
