using AppVendas.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppVendas.Services.Base
{
    public abstract class DataStore<T, TRepository> : IDataStore<T> 
        where T : IEntidade, new()
        where TRepository : class, IRepository<T>
    {
        protected TRepository Repositorio { get; }

        public DataStore()
        {
            Repositorio = DependencyService.Get<TRepository>();
        }

        public async Task<bool> AddAsync(T entidade)
        {
            await Repositorio.SalvarAsync(entidade).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> UpdateAsync(T entidade)
        {
            await Repositorio.SalvarAsync(entidade).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entidade = await Repositorio.ObterAsync(id).ConfigureAwait(false);
            await Repositorio.ExcluirAsync(entidade).ConfigureAwait(false);
            return true;
        }

        public async Task<T> GetAsync(int id)
        {
            return await Repositorio.ObterAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetManyAsync()
        {
            return await Repositorio.ObterTodosAsync().ConfigureAwait(false);
        }
    }
}