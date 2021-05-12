using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeSchool.Data
{
    public abstract class DataContext : DbContext
    {

        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);

            PreventCascadeDelete(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static DbContextOptions CreateDbContextOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            return optionsBuilder.UseSqlServer(connectionString, 
                options => options.EnableRetryOnFailure()).Options;
        }

        private static void PreventCascadeDelete(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
        }
    }
}
