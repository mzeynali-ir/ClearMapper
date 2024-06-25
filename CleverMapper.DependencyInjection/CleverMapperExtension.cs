using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleverMapperLibrary
{
    public static class CleverMapperExtension
    {
        public static IServiceCollection UseCleverMapper(this IServiceCollection services, Action<CleverMapperOption> option, ServiceLifetime? serviceLifetime = ServiceLifetime.Scoped)
        {

            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<CleverMapper>(i => new CleverMapper(option));
                    break;


                case ServiceLifetime.Scoped:
                    services.AddScoped<CleverMapper>(i => new CleverMapper(option));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient<CleverMapper>(i => new CleverMapper(option));
                    break;
            }

            return services;
        }
    }

}


