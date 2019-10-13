using AppVendas.Models;
using AppVendas.ViewModels.Base;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public partial class NovoPedidoViewModel
    {
        public class ProdutoViewModel : BaseViewModel
        {
            private readonly Produto _produto;
            private decimal quantidade;

            public Command AdicionarUmCommand => new Command(AdicionarUm);

            public Command RemoverUmCommand => new Command(SubtrairUm);

            public ProdutoViewModel(Produto produto)
            {
                _produto = produto;
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
                    {
                        OnPropertyChanged(nameof(ValorTotal));
                    }
                }
            }
            public decimal ValorTotal => Valor * Quantidade;

            private void AdicionarUm()
            {
                Quantidade++;
            }

            private void SubtrairUm()
            {
                Quantidade--;
                if (Quantidade <= 0)
                    Quantidade = 0;
            }
        }
    }
}
