using AppVendas.Models;
using AppVendas.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>
    {
        public Task<List<Cliente>> ObterPorUsuario(int usuarioId)
        {
            return Database.QueryAsync<Cliente>($"SELECT * FROM Cliente WHERE Id IN (SELECT ClienteId FROM UsuarioCliente WHERE UsuarioId = ?)", usuarioId);
        }
    }
}
