using AppVendas.Models;
using AppVendas.Repository;
using AppVendas.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public class MockDataStoreClientes : DataStore<Cliente, ClienteRepository>, IDataStoreClientes
    {
        public Task<List<Cliente>> ObterPorUsuario(int usuarioId)
        {
            return Repositorio.ObterPorUsuario(usuarioId);
        }
    }
}