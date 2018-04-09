using Insurinator.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Insurinator.Models.Entities.InsuranceDefinitions
{
    public class VehicleInsuranceDefinition : InsuranceDefinition, IModelWithRelation
    {
        public enum VehicleType
        {
            Small,
            Medium,
            Big,
        }

        public float MinimumLitrage { get; set; }
        public float MaximumLitrage { get; set; }

        public int MinimumYear { get; set; }

        public bool HasRoadAssistanceIncluded { get; set; }

        public override InsuranceType Kind { get; } = InsuranceType.CarInsurance;

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceDefinition>()
                .HasMany(a => a.InsuranceEntries)
                .WithOne(n => n.Definition);
        }
    }
}
