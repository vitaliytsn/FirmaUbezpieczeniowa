using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurinator.Interfaces.Services
{
    public interface IServiceBase<T> : IDisposable where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWhereAsync(Predicate<T> predicate);
        Task<T> FirstAsync(Predicate<T> predicate);

        T Add(T client);
        void Delete(T client);
        void Update(T client);

        Task SaveChangesAsync();
    }
}
