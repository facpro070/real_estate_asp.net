﻿using MessagingMicroservice.Services.Email;
using MessagingMicroservice.Services.Notification;
using RealEstate.Shared.Data.Repository;

namespace MessagingMicroservice.Properties
{
    public static class MessagingStartupExtentions
    {
        public static IServiceCollection AddRepositoriesAndContexts(this IServiceCollection services)
        {
            // Services
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<INotificationService, NotificationService>();

            // Repositories
            services.AddScoped<INotificationRepository>();
            services.AddScoped<IRepository, Repository>(); //base repo implementation

            return services;
        }
    }
}
