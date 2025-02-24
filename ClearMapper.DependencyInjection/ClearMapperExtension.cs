﻿using Microsoft.Extensions.DependencyInjection;
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
                    services.AddSingleton<IMapper>(i => new ClearMapper(option));
                    break;


                case ServiceLifetime.Scoped:
                    services.AddScoped<IClearMapper>(i => new ClearMapper(option));
                    services.AddScoped<IMapper>(i => new ClearMapper(option));
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient<IClearMapper>(i => new ClearMapper(option));
                    services.AddTransient<IMapper>(i => new ClearMapper(option));
                    break;
            }

            return services;
        }

        public static IServiceCollection UseClearMapper(
            this IServiceCollection services,
            ServiceLifetime? serviceLifetime = ServiceLifetime.Scoped)
        {

            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<IClearMapper>(i => new ClearMapper());
                    services.AddSingleton<IMapper>(i => new ClearMapper());
                    break;


                case ServiceLifetime.Scoped:
                    services.AddScoped<IClearMapper>(i => new ClearMapper());
                    services.AddScoped<IMapper>(i => new ClearMapper());
                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient<IClearMapper>(i => new ClearMapper());
                    services.AddTransient<IMapper>(i => new ClearMapper());
                    break;
            }

            return services;
        }
    }

}


