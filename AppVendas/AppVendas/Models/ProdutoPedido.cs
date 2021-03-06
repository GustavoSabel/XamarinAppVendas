﻿using AppVendas.Models.Base;

namespace AppVendas.Models
{
    public class ProdutoPedido
    {
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Quantidade { get; set; }
    }
}
