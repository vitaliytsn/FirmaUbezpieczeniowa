using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Insurinator.Models;
using Insurinator.Models.Entities;
using Insurinator.Models.Entities.InsuranceDefinitions;
using Insurinator.Models.Entities.InsuranceEntries;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Insurinator.DataAccess
{
    public class InsuranceDbContext : DbContext
    {
        static InsuranceDbContext()
        {

        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<InsuranceEvent> InsuranceEvents { get; set; }
        public DbSet<PropertyInsuranceEntry> PropertyInsuranceEntries { get; set; }
        public DbSet<VehicleInsuranceEntry> VehicleInsuranceEntries { get; set; }
        public DbSet<VehicleInsuranceDefinition> VehicleInsuranceDefinitions { get; set; }
        public DbSet<PropertyInsuranceDefinition> PropertyInsuranceDefinitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Batteries.Init();
            optionsBuilder.UseSqlite("Data Source=inurances.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var modelType in GetClassesFromNamespace())
                modelType.GetMethod("OnModelCreating").Invoke(null, new object[] {modelBuilder});

            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<Type> GetClassesFromNamespace()
        {
            var @interface = typeof(IModelWithRelation);
            var @namespace = "Insurinator.Models.Entities";

            return Assembly.GetAssembly(typeof(Client))
                .GetTypes()
                .Where(t => t.IsClass && (t.Namespace?.Contains(@namespace) ?? false) &&
                            @interface.IsAssignableFrom(t));
        }
    }
}