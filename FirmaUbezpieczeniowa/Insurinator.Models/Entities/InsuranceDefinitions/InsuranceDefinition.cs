using System;
using System.Collections.Generic;
using Insurinator.Models.Entities.InsuranceEntries;
using Insurinator.Models.Enums;

namespace Insurinator.Models.Entities.InsuranceDefinitions
{
    public abstract class InsuranceDefinition
    {
        public long Id { get; set; }

        public string Name { get; internal set; }
        public string Description { get; internal set; }

        public virtual float BasePricePerMonth { get; internal set; }

        public DateTime MinimumDuration { get; internal set; }
        public DateTime MaximumDuration { get; internal set; }

        public abstract InsuranceType Kind { get; }

        public virtual ICollection<InsuranceEntry> InsuranceEntries { get; set; }
    }
}
