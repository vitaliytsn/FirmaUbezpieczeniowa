using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Insurinator.Models.Entities.InsuranceEntries
{
    public class PropertyInsuranceEntry : InsuranceEntry, IModelWithRelation
    {
        public string Address { get; set; }
        public int DeclaredValue { get; set; }
        public float SquareMeters { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntry>()
                .HasMany(a => a.Events)
                .WithOne(n => n.InsuranceEntry);
        }
    }
}
