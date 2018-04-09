using System.Collections.Generic;
using Insurinator.Models.Entities.InsuranceDefinitions;

namespace Insurinator.Models.Entities.InsuranceEntries
{
    public abstract class InsuranceEntry
    {
        public long Id { get; set; }

        public Client Client { get; set; }
        public InsuranceDefinition Definition { get; set; }
        public virtual ICollection<InsuranceEvent> Events { get; set; }

        public float PricePerMonth { get; set; }

        public Employee Issuer { get; set; }
    }
}
