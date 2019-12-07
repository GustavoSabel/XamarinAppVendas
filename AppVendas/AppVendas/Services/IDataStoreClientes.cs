using AppVendas.Models;
using AppVendas.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public interface IDataStoreClientes : IDataStore<Cliente>
    {
        Task<List<Cliente>> ObterPorUsuario(int usuarioId);
    }
}