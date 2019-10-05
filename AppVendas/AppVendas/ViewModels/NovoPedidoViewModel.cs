using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public class NovoPedidoViewModel : BaseViewModel
    {
        private readonly IDataStoreProdutos _dataStoreProdutos;

        public ObservableCollection<ProdutoViewModel> Produtos { get; set; }

        public decimal ValorTotal => Produtos.Sum(x => x.ValorTotal);

        public bool Loaded { get; private set; }

        public ICommand LoadCommand { get; }

        public NovoPedidoViewModel(IDataStoreProdutos dataStoreProdutos, int clienteId)
        {
            _dataStoreProdutos = dataStoreProdutos;
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
                var items = await _dataStoreProdutos.ObterPorCliente(clienteId);
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

        public class ProdutoViewModel : BaseViewModel
        {
            private readonly Produto _produto;
            private decimal quantidade;
            public ICommand AdicionarUmCommand { get; }
            public ICommand RemoverUmCommand { get; }

            public ProdutoViewModel(Produto produto)
            {
                _produto = produto;
                AdicionarUmCommand = new Command(() => Quantidade++);
                RemoverUmCommand = new Command(() =>
                {
                    Quantidade--;
                    if (Quantidade < 0)
                        Quantidade = 0;
                });
            }

            public int Id => _produto.Id;
            public string Descricao => _produto.Descricao;
            public string Unidade => _produto.Unidade;
            public decimal Valor => _produto.Valor;
            public decimal ValorUnitario => _produto.ValorUnitario;

            public decimal Quantidade
            {
                get => quantidade;
                set
                {
                    if (SetProperty(ref quantidade, value))
                        OnPropertyChanged(nameof(ValorTotal));
                }
            }
            public decimal ValorTotal => ValorUnitario * Quantidade;
        }
    }
}
