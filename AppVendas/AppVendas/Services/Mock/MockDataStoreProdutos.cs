using AppVendas.Models;
using AppVendas.Repository;
using AppVendas.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public class MockDataStoreProdutos : DataStore<Produto, ProdutoRepository>, IDataStoreProdutos
    {
        public async Task<IEnumerable<Produto>> ObterPorCliente(int clienteId)
        {
            return await GetManyAsync().ConfigureAwait(false);
        }
    }
}