using AppVendas.Models.Base;
using SQLite;
using System;
using System.Collections.Generic;

namespace AppVendas.Models
{
    public class Pedido : Entidade
    {
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Data { get; set; }

        [Ignore]
        public List<ProdutoPedido> Produtos { get; set; }
    }
}
