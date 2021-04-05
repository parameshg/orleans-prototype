using IoT.Api.Dependencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IoT.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(config => config.SwaggerDoc("v1", new OpenApiInfo { Title = "IoT.Api", Version = "v1" }));

            services.AddOrleans(Configuration.GetSection("Orleans"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "IoT.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseOrleans();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}