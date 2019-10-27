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
            Database.Conecao.CreateTableAsync<T>().Wait();
        }

        public virtual Task<List<T>> ObterTodosAsync()
        {
            return Database.Conecao.Table<T>().ToListAsync();
        }

        public virtual Task<T> ObterAsync(int id)
        {
            return Database.Conecao.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task SalvarAsync(T entidade)
        {
            if (entidade.Id != 0)
            {
                await Database.Conecao.UpdateAsync(entidade).ConfigureAwait(false);
            }
            else
            {
                var id = await Database.Conecao.InsertAsync(entidade).ConfigureAwait(false);
                entidade.Id = id;
            }
        }

        public virtual Task ExcluirAsync(T entidade)
        {
            return Database.Conecao.DeleteAsync(entidade);
        }
    }
}
