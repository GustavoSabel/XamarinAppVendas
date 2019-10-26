using AppVendas.Models.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.Services.Base
{
    public abstract class DataStore<T> : IDataStore<T> where T : IEntidade
    {
        protected readonly List<T> Entidades = new List<T>();
        private int _idAtual;

        public DataStore()
        {
            Entidades = Load().ToList();
            _idAtual = Entidades.LastOrDefault()?.Id ?? 0;
        }

        protected abstract IEnumerable<T> Load();

        public async Task<bool> AddAsync(T cliente)
        {
            cliente.Id = ++_idAtual;
            Entidades.Add(cliente);

            return await Task.FromResult(true).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(T cliente)
        {
            var oldItem = Entidades.Where(x => x.Id == cliente.Id).FirstOrDefault();
            Entidades.Remove(oldItem);
            Entidades.Add(cliente);

            return await Task.FromResult(true).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var oldItem = Entidades.Where(x => x.Id == id).FirstOrDefault();
            Entidades.Remove(oldItem);

            return await Task.FromResult(true).ConfigureAwait(false);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Task.FromResult(Entidades.FirstOrDefault(s => s.Id == id)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetManyAsync()
        {
            return await Task.FromResult(Entidades).ConfigureAwait(false);
        }
    }
}