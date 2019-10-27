using AppVendas.Models;
using AppVendas.Repository;
using AppVendas.Services.Base;

namespace AppVendas.Services
{
    public class MockDataStoreClientes : DataStore<Cliente, ClienteRepository>, IDataStoreClientes
    {
    }
}