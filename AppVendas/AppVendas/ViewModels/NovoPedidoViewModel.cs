using AppVendas.Models;
using AppVendas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public class NovoPedidoViewModel : BaseViewModel<Produto>
    {
        public IDataStoreProdutos DataStoreProdutos => (IDataStoreProdutos)DataStore;
        public ObservableCollection<ProdutoViewModel> Produtos { get; set; }

        public decimal ValorTotal => Produtos.Sum(x => x.ValorTotal);

        public bool Loaded { get; private set; }

        public Command LoadCommand { get; }

        public NovoPedidoViewModel(int clienteId)
        {
            Produtos = new ObservableCollection<ProdutoViewModel>();
            LoadCommand = new Command(async () => await ExecuteLoadItemsCommand(clienteId));
        }

        async Task ExecuteLoadItemsCommand(int clienteId)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Produtos.Clear();
                var items = await DataStoreProdutos.ObterPorCliente(clienteId);
                foreach (var item in items)
                {
                    Produtos.Add(new ProdutoViewModel(item));
                }
                Loaded = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public class ProdutoViewModel
        {
            private readonly Produto _produto;

            public ProdutoViewModel(Produto produto)
            {
                _produto = produto;
            }

            public int Id => _produto.Id;
            public string Descricao => _produto.Descricao;
            public string Unidade => _produto.Unidade;
            public decimal Valor => _produto.Valor;
            public decimal ValorUnitario => _produto.ValorUnitario;

            public decimal Quantidade { get; set; }
            public decimal ValorTotal => ValorUnitario * ValorTotal;
        }
    }
}
