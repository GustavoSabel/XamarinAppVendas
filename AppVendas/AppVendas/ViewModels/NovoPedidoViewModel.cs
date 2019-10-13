using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public partial class NovoPedidoViewModel : BaseViewModel
    {
        private readonly IDataStoreProdutos _dataStoreProdutos;
        private IReadOnlyList<ProdutoViewModel> _todosProdutos;
        private IReadOnlyList<ProdutoViewModel> produtos;

        public IReadOnlyList<ProdutoViewModel> Produtos
        {
            get => produtos;
            set
            {
                produtos = value;
                OnPropertyChanged();
            }
        }

        public Command<string> FiltroCommand => new Command<string>((fitro) =>
        {
            if (string.IsNullOrEmpty(fitro))
                Produtos = _todosProdutos.ToList();
            Produtos = _todosProdutos.Where(x => x.Descricao.Contains(fitro, StringComparison.InvariantCultureIgnoreCase)).ToList();
        });

        public decimal ValorTotal => _todosProdutos?.Sum(x => x.ValorTotal) ?? 0;

        public bool Loaded { get; private set; }

        public ICommand LoadCommand { get; }

        public NovoPedidoViewModel(IDataStoreProdutos dataStoreProdutos, int clienteId)
        {
            _dataStoreProdutos = dataStoreProdutos;
            LoadCommand = new Command(async () => await ExecuteLoadItemsCommand(clienteId));
        }

        async Task ExecuteLoadItemsCommand(int clienteId)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await _dataStoreProdutos.ObterPorCliente(clienteId);
                _todosProdutos = ConverterParaViewModel(items);
                Produtos = _todosProdutos.ToList();
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

        private List<ProdutoViewModel> ConverterParaViewModel(IEnumerable<Produto> items)
        {
            var produtos = new List<ProdutoViewModel>();
            foreach (var item in items)
            {
                var produtoVM = new ProdutoViewModel(item);
                produtoVM.PropertyChanged += (sender, e) =>
                {
                    OnPropertyChanged(nameof(ValorTotal));
                };
                produtos.Add(produtoVM);
            }
            return produtos;
        }
    }
}
