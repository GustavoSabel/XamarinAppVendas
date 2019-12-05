using AppVendas.Models.Base;

namespace AppVendas.Models
{
    public class Usuario : Entidade
    {
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
