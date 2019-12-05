using AppVendas.Models;
using AppVendas.Services.Base;

namespace AppVendas.Services
{
    public interface IDataStoreUsuarios : IDataStore<Usuario>
    {
        System.Threading.Tasks.Task<Usuario> ValidarUsuarioSenha(string nomeUsuario, string senha);
    }
}