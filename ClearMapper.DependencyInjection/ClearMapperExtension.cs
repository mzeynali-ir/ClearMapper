using Microsoft.Extensions.DependencyInjection;
using System;

namespace ClearMapperLibrary
{
    public static class ClearMapperExtension
    {
        public static IServiceCollection UseClearMapper(this IServiceCollection services, Action<ClearMapperOption> option, ServiceLifetime? serviceLifetime = ServiceLifetime.Scoped)
        {

            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<ClearMapper>(i => new ClearMapper(option));
                    break;


                case ServiceLifetime.Scoped:
                    services.AddScoped<ClearMapper>(i => new ClearMapper(option));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient<ClearMapper>(i => new ClearMapper(option));
                    break;
            }

            return services;
        }
    }

}


