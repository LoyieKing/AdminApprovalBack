using System;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal class AabDbContext : DbContext
    {
        private readonly Action<DbContextOptionsBuilder> _optionAction;

        public AabDbContext(Action<DbContextOptionsBuilder> options)
        {
            _optionAction = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _optionAction?.Invoke(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}