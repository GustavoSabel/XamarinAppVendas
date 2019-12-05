using AppVendas.Helpers;
using AppVendas.Models;
using AppVendas.Repository;
using AppVendas.Services.Base;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public class MockDataStoreUsuario : DataStore<Usuario, UsuarioRepository>, IDataStoreUsuarios
    {
        public async Task<Usuario> ValidarUsuarioSenha(string nomeUsuario, string senha)
        {
            var usuario = await Repositorio.ObterPeloNomeUsuario(nomeUsuario).ConfigureAwait(false);
            if (usuario == null)
                return null;

            if (HashHelper.Comparar(senha, usuario.Senha))
                return usuario;
            return null;
        }
    }
}