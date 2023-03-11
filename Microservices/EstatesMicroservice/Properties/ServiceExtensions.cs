﻿using EstatesMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using RealEstate.ApiGateway.Authentication;
using RealEstate.ApiGateway.Authentication.Contracts;
using RealEstate.ApiGateway.ServiceExtensions;
using RealEstate.Shared.Data.Context;
using RealEstate.Shared.Data.Repository;

namespace EstatesMicroservice.Properties
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository), typeof(Repository));
            services.AddScoped(typeof(IApplicationDbRepository), typeof(ApplicationDbRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IEstateService), typeof(EstateService));

            return services;
        }

        public static IServiceCollection Use_PostgreSQL_Estates_Context(this IServiceCollection services, IConfiguration config)
        {
            // This just needs to be called once on application startup
            EnvironmentConfig.LoadFromEnvironmentVariable();

            // Fetch config from connectionStrings.json
            var estatesConnectionString = EnvironmentConfig.Current.PostgreEstatesConnection;

            // Microdatabases
            services.AddDbContext<EstatesDBContext>(options => options.UseNpgsql(estatesConnectionString));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
