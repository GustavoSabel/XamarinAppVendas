using AppVendas.Models.Base;

namespace AppVendas.Models
{
    public class Produto : Entidade
    {
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorUnitario { get; set; }
        public byte[] Foto { get; internal set; }
    }
}
