using System.Collections.Generic;
using System.Threading.Tasks;
using AppVendas.Models;
using AppVendas.Services.Base;

namespace AppVendas.Services
{
    public interface IDataStorePedido : IDataStore<Pedido>
    {
        Task<List<Pedido>> ObterPorCliente(int clienteId);
    }
}