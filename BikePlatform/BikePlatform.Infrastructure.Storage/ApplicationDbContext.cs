using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePlatform.Domain.BikeRepairAggregate;
using Microsoft.EntityFrameworkCore;

namespace BikePlatform.Infrastructure.Storage
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RepairRequest>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<RepairRequest>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

        }
    }
}
