using AppVendas.Services;
using AppVendas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        private readonly IDataStorePedido _dataStorePedido;
        private readonly IDataStoreClientes _dataStoreClientes;

        public string ClienteRazaoSocial { get; set; }

        public List<ProdutoViewModel> Produtos { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime Data { get; set; }

        public bool Loaded { get; private set; }

        public PedidoViewModel(IDataStorePedido dataStorePedido, IDataStoreClientes dataStoreClientes)
        {
            _dataStorePedido = dataStorePedido;
            _dataStoreClientes = dataStoreClientes;
        }

        public async Task Carregar(int pedidoId)
        {
            Loaded = true;
            var pedido = await _dataStorePedido.GetAsync(pedidoId);
            var cliente = await _dataStoreClientes.GetAsync(pedido.ClienteId);

            ClienteRazaoSocial = cliente.RazaoSocial;
            Data = pedido.Data;
            ValorTotal = pedido.ValorTotal;
            Produtos = pedido.Produtos.Select(x => new ProdutoViewModel(x)).ToList();

            OnPropertyChanged(nameof(ClienteRazaoSocial));
            OnPropertyChanged(nameof(Data));
            OnPropertyChanged(nameof(ValorTotal));
            OnPropertyChanged(nameof(Produtos));
        }
    }
}
