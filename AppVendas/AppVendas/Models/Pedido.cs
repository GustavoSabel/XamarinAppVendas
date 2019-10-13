using AppVendas.Models.Base;
using System;
using System.Collections.Generic;

namespace AppVendas.Models
{
    public class Pedido : Entidade
    {
        public int ClienteId { get; set; }
        public List<ProdutoPedido> Produtos { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Data { get; set; }
    }
}
