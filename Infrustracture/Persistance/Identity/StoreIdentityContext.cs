using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Identity
{
    public class StoreIdentityContext : IdentityDbContext
    {
        public StoreIdentityContext(DbContextOptions<StoreIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Address>().ToTable("Addresses");
        }
        public DbSet<Address> Addresses { get; set; }

    }
}