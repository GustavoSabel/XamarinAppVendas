using AppVendas.Models;
using AppVendas.Services;
using System.Threading.Tasks;

namespace AppVendas.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public Task<Usuario> ObterPeloNomeUsuario(string nomeUsuario)
        {
            return Database.FindWithQueryAsync<Usuario>($"SELECT * FROM Usuario WHERE nomeUsuario = ?", nomeUsuario);
        }
    }
}
