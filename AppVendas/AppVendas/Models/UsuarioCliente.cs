namespace AppVendas.Models
{
    /// <summary>
    /// Clientes que o usuário tem acesso
    /// </summary>
    public class UsuarioCliente
    {
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
    }
}
