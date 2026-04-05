using Domain.Contracts;
using Domain.Contracts.Domain.Contracts;
using Domain.Entities;
using E_Commerce.Extensions;
using Microsoft.AspNetCore.Identity;
using Persistance.Identity;
using Persistance.Repositories;
using Persistance.Services;
using Services;
using Services.Abstractions;

namespace Save_Serve
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddInfraStructureServices(builder.Configuration);

            // ⭐ Register JWT Token Service
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

            builder.Services.AddControllers();
            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentaion.AssemblyReference).Assembly);

            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddScoped<IConsumerRepository, ConsumerRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowFrontend");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}