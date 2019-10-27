using AppVendas.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public interface IRepository<T> where T : IEntidade, new()
    {
        Task ExcluirAsync(T item);
        Task<T> ObterAsync(int id);
        Task<List<T>> ObterTodosAsync();
        Task SalvarAsync(T item);
    }
}