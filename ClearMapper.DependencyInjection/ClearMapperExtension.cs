using Microsoft.Extensions.DependencyInjection;
using System;

namespace ClearMapperLibrary
{
    public static class ClearMapperExtension
    {
        public static IServiceCollection UseClearMapper(
            this IServiceCollection services,
            Action<ClearMapperOption> option,
            ServiceLifetime? serviceLifetime = ServiceLifetime.Scoped)
        {

            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<IClearMapper>(i => new ClearMapper(option));
                    break;


                case ServiceLifetime.Scoped:
                    services.AddScoped<IClearMapper>(i => new ClearMapper(option));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient<IClearMapper>(i => new ClearMapper(option));
                    break;
            }

            return services;
        }
    }

}


