using System.Collections.Generic;
using System.Threading.Tasks;
using AppVendas.Models;
using AppVendas.Services.Base;

namespace AppVendas.Services
{
    public interface IDataStoreProdutos : IDataStore<Produto>
    {
        Task<IEnumerable<Produto>> ObterPorCliente(int clienteId);
    }
}