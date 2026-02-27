using Domain.Contracts;
using Domain.Entities;
using E_Commerce.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Dates;
using Persistance.Identity;
using Persistance.Repositories;


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

            //   async Task inilializeDbasync (WebApplication app)
            //{
            //    //Create Object From Type  That Implements IDbinitializer
            //    using var Scope = app.Services.CreateScope();
            //    var dbinitailizer = Scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            //    await dbinitailizer.InitializeAsync();
            //    await dbinitailizer.InitializeIdentityAsync();

            //}
            async Task inilializeDbasync(WebApplication app)
            {
                using var scope = app.Services.CreateScope();
                var services = scope.ServiceProvider;

                try
                {
                    var dbinitailizer = services.GetRequiredService<IDbInitializer>();
                    await dbinitailizer.InitializeAsync();
                    await dbinitailizer.InitializeIdentityAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DB Init Error: " + ex.Message);
                    throw;
                }
            }

        }
    }
   
}
