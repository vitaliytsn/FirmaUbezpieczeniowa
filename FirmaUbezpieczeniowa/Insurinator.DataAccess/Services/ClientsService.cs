using System;
using System.Diagnostics;
using System.Linq;
using Insurinator.Interfaces;
using Insurinator.Interfaces.Services;
using Insurinator.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Insurinator.DataAccess.Services
{
    public class ClientsService : ServiceBase<Client>, IClientsService
    {
        [Conditional("DEBUG")]
        internal void DropAll()
        {
            _context.Database.EnsureDeleted();
            _context.SaveChanges();
            using (var db = new InsuranceDbContext())
            {
                try
                {
                    db.Database.Migrate();
                }
                catch (Exception e)
                {
                    //migrated
                }

            }
        }
    }
}