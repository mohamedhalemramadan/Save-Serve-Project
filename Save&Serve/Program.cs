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

            // 1. تعريف سياسة الـ CORS (تعديلك إنتي)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy => policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            // 2. إضافة خدمات المشروع الأساسية
            builder.Services.AddInfraStructureServices(builder.Configuration);

            // تسجيل خدمة الـ JWT
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

            // إعداد الـ Controllers وربطها بالـ Presentation Layer
            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentaion.AssemblyReference).Assembly);

            // تسجيل الـ Service Manager
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

            // 3. إعدادات بيئة التطوير
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowFrontend");
            app.UseHttpsRedirection();

            // 4. تفعيل الـ CORS (لازم يكون قبل الـ Authorization)
            app.UseCors("AllowReactApp");

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}