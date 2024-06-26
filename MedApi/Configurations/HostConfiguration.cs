﻿namespace MedApi.Configurations
{
    public static partial class HostConfiguration
    {
        public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
        {
            builder
                //.AddValidators()
                .AddMappers()
                .AddNotificationInfrastructure()
                .AddVerificationInfrastructure()
                .AddIdentityInfrastructure()
                .AddDevTools(builder.Configuration)
                .AddEntityService()
                .AddEntityRepositories()
                .AddExposers();

            return new(builder);
        }

        public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
        {
            await app.SeedDataAsync();

            app
                .UseIdentityInfrastructure()
                .UseExposers()
                .UseDevTools(); 

            return app;
        }
    }
}