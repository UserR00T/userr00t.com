using System.Threading;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence;
using Pointer.Presentation.Api.Managers;

namespace Pointer.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: improve
            // Wait for 1 second in container environment for the database service to start.
            if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
            {
                Thread.Sleep(1000);
            }
            Task.Run(async () => await services.AddPersistence(Configuration)).Wait();
            services.AddRouting(x => x.LowercaseUrls = true);
            services.AddControllers();

            var tokenManager = new TokenManager(Configuration);
            tokenManager.AddJwt(services);
            services.AddSingleton(tokenManager);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pointer.Presentation.Api",
                    Version = "v1",
                    Description = "Presentation API layer for https://userr00t.com - https://github.com/UserR00T/userr00t.com",
                    Contact = new OpenApiContact
                    {
                        Name = "UserR00T",
                        Url = new System.Uri("https://userr00t.com"),
                        Email = "contact@userr00t.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "GPLv3",
                        Url = new System.Uri("https://github.com/UserR00T/userr00t.com/blob/main/LICENSE")
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });
            });

            services.TryAddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }
            app.UseSwagger(x => x.RouteTemplate = "/api/swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Pointer.Presentation.Api v1");
                c.RoutePrefix = "api";
            });

            app.UseCors(x => x.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
