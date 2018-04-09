using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurinator.Models.Entities.InsuranceDefinitions;
using Microsoft.EntityFrameworkCore;

namespace Insurinator.Models.Entities.InsuranceEntries
{
    public class VehicleInsuranceEntry : InsuranceEntry , IModelWithRelation
    {
        public int YearOfProduction { get; set; }
        public string Make { get; set; }
        public float Litrage { get; set; }
        public string CarPlate { get; set; }

        public VehicleInsuranceDefinition.VehicleType VehicleType { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntry>()
                .HasMany(a => a.Events)
                .WithOne(n => n.InsuranceEntry);
        }
    }
}
