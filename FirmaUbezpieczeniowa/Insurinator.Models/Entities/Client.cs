using System.Collections.Generic;
using Insurinator.Models.Entities.InsuranceEntries;
using Insurinator.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Insurinator.Models.Entities
{
    public class Client : IModelWithRelation
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public ClientType Type { get; set; }

        public virtual ICollection<InsuranceEntry> Insurances { get; set; } = new HashSet<InsuranceEntry>();

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(a => a.Insurances)
                .WithOne(n => n.Client);
        }
    }
}
