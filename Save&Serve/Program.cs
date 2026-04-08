using Domain.Contracts;
using Domain.Contracts.Domain.Contracts;
using Domain.Entities;
using E_Commerce.Extensions;
using Microsoft.AspNetCore.Identity;
using Persistance.Identity;
using Persistance.Repositories;
using Persistance.Services;
using Presentaion;
using Servcies;
using Servcies.Abstractions;
using Services;
using Services.Abstractions;

namespace Save_Serve
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy => policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

           
            builder.Services.AddInfraStructureServices(builder.Configuration);

         
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
           
            builder.Services.AddScoped<IConsumerService, ConsumerService>();  
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();

           

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentaion.AssemblyReference).Assembly);

          
            builder.Services.AddScoped<IServiceManager, ServiceManager>();

            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddScoped<IConsumerRepository, ConsumerRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


          
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins(
                            "http://localhost:3000",  // React default
                            "http://localhost:5173",  // Vite default
                            "http://localhost:4200")  // Angular default
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
            });

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowFrontend");
            app.UseHttpsRedirection();
           await app.SeedDbAsync();

           
           // app.UseCors("AllowReactApp");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}