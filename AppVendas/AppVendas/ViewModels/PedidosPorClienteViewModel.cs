using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.ViewModels
{
    public class PedidosPorClienteViewModel : BaseViewModel
    {
        private readonly IDataStorePedido _dataStoreVendas;

        public bool Loaded { get; private set; }
        public IReadOnlyList<Pedido> Pedidos { get; private set; } = new List<Pedido>();
        public decimal ValorTotal => Pedidos.Sum(x => x.ValorTotal);
        public string ClienteNomeFantasia { get; private set; }

        public PedidosPorClienteViewModel(IDataStorePedido dataStoreVendas)
        {
            Title = "Pedidos anteriores";
            _dataStoreVendas = dataStoreVendas;
        }

        internal async Task Carregar(Cliente cliente)
        {
            Loaded = true;
            Pedidos = (await _dataStoreVendas.ObterPorCliente(cliente.Id).ConfigureAwait(false)).OrderByDescending(x => x.Data).ToList();
            ClienteNomeFantasia = cliente.NomeFantasia;
            OnPropertyChanged(nameof(ClienteNomeFantasia));
            OnPropertyChanged(nameof(Pedidos));
            OnPropertyChanged(nameof(ValorTotal));
        }
    }
}
