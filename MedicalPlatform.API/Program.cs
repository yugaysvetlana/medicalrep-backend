
using Microsoft.Extensions.Configuration;
using MedicalPlatform.Persistence;
using MedicalPlatform.Application;
using MedicalPlatform.Persistence.Mappings;
using MedicalPlatform.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using MedicalPlatform.API.Extensions;

namespace MedicalPlatform.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(5000);
                serverOptions.ListenAnyIP(5001, listenOptions =>
                {
                    listenOptions.UseHttps();
                });
            });
            // Add services to the container.
            var configuration = builder.Configuration;

            builder.Services.AddApiAuthentication(configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            //builder.Services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

            builder.Services
                .AddPersistence(configuration)
                .AddApplication()
                .AddInfrastructure();

            builder.Services.AddAutoMapper(typeof(DataBaseMappings));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
