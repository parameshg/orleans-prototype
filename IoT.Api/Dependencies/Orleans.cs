using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Serialization;
using System.Collections.Generic;

namespace IoT.Api.Dependencies
{
    public static class Runtime
    {
        public static IServiceCollection AddOrleans(this IServiceCollection services, IConfiguration configuration)
        {
            var client = new ClientBuilder()
            .UseAdoNetClustering(config => config.Configure(options =>
            {
                options.ConnectionString = configuration["Database"];
                options.Invariant = "System.Data.SqlClient";
            }))
            .Configure<ClusterOptions>(config =>
            {
                config.ClusterId = "development";
                config.ServiceId = "calculator";
            })
            .Configure<SerializationProviderOptions>(config =>
            {
                config.SerializationProviders.Clear();
                config.SerializationProviders.Add(typeof(BondSerializer));
                config.FallbackSerializationProvider = typeof(BinaryFormatterSerializer);
            })
            .ConfigureLogging(config => config.AddConsole())
            .Build();

            services.AddSingleton(client);

            return services;
        }

        public static IApplicationBuilder UseOrleans(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<IClusterClient>().Connect().GetAwaiter().GetResult();

            return app;
        }
    }
}