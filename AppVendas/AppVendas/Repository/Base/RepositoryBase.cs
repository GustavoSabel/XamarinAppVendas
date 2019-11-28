using AppVendas.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : IEntidade, new()
    {
        protected ConexaoApp Database { get; }

        public RepositoryBase()
        {
            Database = ConexaoApp.Instancia;
        }

        public virtual Task<List<T>> ObterTodosAsync()
        {
            return Database.Table<T>().ToListAsync();
        }

        public virtual Task<T> ObterAsync(int id)
        {
            return Database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task SalvarAsync(T entidade)
        {
            if (entidade.Id != 0)
                await Database.UpdateAsync(entidade).ConfigureAwait(false);
            else
                await Database.InsertAsync(entidade).ConfigureAwait(false);
        }

        public virtual Task ExcluirAsync(T entidade)
        {
            return Database.DeleteAsync(entidade);
        }
    }
}
