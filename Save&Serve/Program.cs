using Domain.Contracts;
using Domain.Contracts.Domain.Contracts;
using Domain.Entities;
using E_Commerce.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistance.Identity;
using Persistance.Repositories;
using Persistance.Services;
using Services;
using Services.Abstractions;
using System.Text;

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



            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

                // تكوين المصادقة
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });




            // تسجيل الـ Service Manager
            builder.Services.AddScoped<IServiceManager, ServiceManager>();

            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddScoped<IConsumerRepository, ConsumerRepository>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken =true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
                };

            });

            builder.Services.AddAuthorization();
         



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

           
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
           
            app.UseHttpsRedirection();
            app.SeedDbAsync();
            app.UseRouting();
            // 4. تفعيل الـ CORS (لازم يكون قبل الـ Authorization)
            app.UseCors("AllowFrontend");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();


            app.Run();


            

            
           

            
        }
    }
}