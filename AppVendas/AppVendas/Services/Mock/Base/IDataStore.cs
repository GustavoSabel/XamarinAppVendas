using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Services.Base
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetManyAsync();
    }
}
