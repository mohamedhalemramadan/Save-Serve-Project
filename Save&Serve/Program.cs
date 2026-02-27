using Domain.Contracts;
using Domain.Entities;
using E_Commerce.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Dates;
using Persistance.Identity;
using Persistance.Repositories;
using Servcies;
using Services.Abstractions;


namespace Save_Serve
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfraStructureServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddControllers().AddApplicationPart(typeof(Presentaion.AssemblyReference).Assembly);
            builder.Services.AddScoped<IServiceManager ,ServiceManager>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            await app.SeedDbAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            
            }

        }
    }
   

