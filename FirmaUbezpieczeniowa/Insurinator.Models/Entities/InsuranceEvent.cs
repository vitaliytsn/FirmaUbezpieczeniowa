using System;
using Insurinator.Models.Entities.InsuranceEntries;
using Insurinator.Models.Enums;

namespace Insurinator.Models.Entities
{
    public class InsuranceEvent
    {
        public long Id { get; set; }

        public InsuranceEntry InsuranceEntry { get; set; }
        public DateTime DateTime { get; set; }
        public InsuranceEventType Type { get; set; }
    }
}
