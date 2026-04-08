using System.Text;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using Persistance.Dates;
using Persistance.Identity;
using Persistance.Repositories;

namespace E_Commerce.Extensions
{
    public static class InfraStructureServiceExtensions
    {
        public static IServiceCollection AddInfraStructureServices(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddDbContext<StoreDBContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });


            services.AddDbContext<StoreIdentityContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("IdentityConnection");
                options.UseSqlServer(connectionString);
            });

            services.ConfigureIdentityService();

            return services;
        }

        public static IServiceCollection ConfigureIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<StoreIdentityContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}