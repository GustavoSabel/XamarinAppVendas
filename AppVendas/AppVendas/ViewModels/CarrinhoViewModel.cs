using AppVendas.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using static AppVendas.ViewModels.NovoPedidoViewModel;

namespace AppVendas.ViewModels
{
    public class CarrinhoViewModel : BaseViewModel
    {
        public CarrinhoViewModel(IEnumerable<ProdutoViewModel> produtos)
        {
            Title = "Carrinho";
            Produtos = produtos.ToList();
            foreach (var produto in produtos)
            {
                produto.PropertyChanged -= Produto_PropertyChanged;
                produto.PropertyChanged += Produto_PropertyChanged;
            }
        }

        private void Produto_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var produto = (ProdutoViewModel)sender;
            OnPropertyChanged(nameof(ValorTotal));
            if (produto.Quantidade <= 0)
                OnPropertyChanged(nameof(ProdutosComQuantidade));
        }

        public decimal ValorTotal => Produtos?.Sum(x => x.ValorTotal) ?? 0;

        public IReadOnlyList<ProdutoViewModel> Produtos { get; }
        public IEnumerable<ProdutoViewModel> ProdutosComQuantidade => Produtos.Where(x => x.Quantidade > 0);
    }
}
