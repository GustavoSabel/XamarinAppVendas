using System;

namespace AppVendas.Models
{
    public class Cliente
    {
        public string Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cidade { get; set; }
        public string EstadoSigla { get; set; }
        public string CidadeEstado => Cidade + "/" + EstadoSigla;
        public DateTime? DataUltimoPedido { get; set; }
    }
}
