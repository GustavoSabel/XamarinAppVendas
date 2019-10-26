using AppVendas.Models;
using AppVendas.ViewModels.Base;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public class ProdutoViewModel : BaseViewModel
    {
        private decimal quantidade;

        public Command AdicionarUmCommand => new Command(AdicionarUm);

        public Command RemoverUmCommand => new Command(SubtrairUm);

        public ProdutoViewModel(Produto produto)
        {
            Id = produto.Id;
            Descricao = produto.Descricao;
            Unidade = produto.Unidade;
            Valor = produto.Valor;
            ValorUnitario = produto.ValorUnitario;
        }

        public ProdutoViewModel(ProdutoPedido produto)
        {
            Id = produto.ProdutoId;
            Descricao = produto.Descricao;
            Unidade = produto.Unidade;
            Valor = produto.Valor;
            ValorUnitario = produto.ValorUnitario;
            Quantidade = produto.Quantidade;
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string Unidade { get; private set; }
        public decimal Valor { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public string ValorPorUnidade => Valor.ToString("c2") + " por " + Unidade;

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
