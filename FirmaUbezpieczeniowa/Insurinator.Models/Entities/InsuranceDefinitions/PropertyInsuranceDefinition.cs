using Insurinator.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Insurinator.Models.Entities.InsuranceDefinitions
{
    public class PropertyInsuranceDefinition : InsuranceDefinition, IModelWithRelation
    {
        public enum PropertyType
        {
            House,
            Factory,
            Store
        }

        public int MaximumDeclaredValues { get; set; }
        public int MinimumConstructionYear { get; set; }

        public override InsuranceType Kind { get; } = InsuranceType.PropertyInsurance;

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceDefinition>()
                .HasMany(a => a.InsuranceEntries)
                .WithOne(n => n.Definition);
        }
    }
}
