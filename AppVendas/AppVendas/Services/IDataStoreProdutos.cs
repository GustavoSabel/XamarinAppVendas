using System.Collections.Generic;
using System.Threading.Tasks;
using AppVendas.Models;

namespace AppVendas.Services
{
    public interface IDataStoreProdutos
    {
        Task<IEnumerable<Produto>> ObterPorCliente(int clienteId);
    }
}