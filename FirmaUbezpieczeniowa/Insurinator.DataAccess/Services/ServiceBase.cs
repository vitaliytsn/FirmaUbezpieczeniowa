using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurinator.Interfaces;
using Insurinator.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Insurinator.DataAccess.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly InsuranceDbContext _context;

        public ServiceBase()
        {
            _context = new InsuranceDbContext();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public Task<List<T>> GetAllWhereAsync(Predicate<T> predicate)
        {
            return _context.Set<T>().Where(client => predicate(client)).ToListAsync();
        }

        public Task<T> FirstAsync(Predicate<T> predicate)
        {
            try
            {
                return _context.Set<T>().FirstAsync(client => predicate(client));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public T Add(T client)
        {
            return _context.Add(client).Entity;
        }

        public void Delete(T client)
        {
            _context.Set<T>().Remove(client);
        }

        public void Update(T client)
        {
            _context.Set<T>().Update(client);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}