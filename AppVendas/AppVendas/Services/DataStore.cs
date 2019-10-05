using AppVendas.Models.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public abstract class DataStore<T> : IDataStore<T> where T : IEntidade
    {
        readonly List<T> _entidades = new List<T>();

        public DataStore()
        {
            _entidades = Load().ToList();
        }

        protected abstract IEnumerable<T> Load();

        public async Task<bool> AddAsync(T cliente)
        {
            _entidades.Add(cliente);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(T cliente)
        {
            var oldItem = _entidades.Where(x => x.Id == cliente.Id).FirstOrDefault();
            _entidades.Remove(oldItem);
            _entidades.Add(cliente);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var oldItem = _entidades.Where(x => x.Id == id).FirstOrDefault();
            _entidades.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Task.FromResult(_entidades.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetManyAsync()
        {
            return await Task.FromResult(_entidades);
        }
    }
}