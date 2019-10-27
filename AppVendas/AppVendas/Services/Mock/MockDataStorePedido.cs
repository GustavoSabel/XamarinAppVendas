using System.Collections.Generic;
using System.Threading.Tasks;
using AppVendas.Models;
using AppVendas.Repository;
using AppVendas.Services.Base;

namespace AppVendas.Services
{
    public class MockDataStorePedido : DataStore<Pedido, PedidoRepository>, IDataStorePedido
    {
        public Task<List<Pedido>> ObterPorCliente(int clienteId)
        {
            return Repositorio.ObterPorCliente(clienteId);
        }
    }
}