using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal class AabDbContext : DbContext
    {

        public AabDbContext(DbContextOptions<AabDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}