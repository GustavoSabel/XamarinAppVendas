using System;
using System.IO;
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
            if (produto is null)
                throw new ArgumentNullException(nameof(produto));

            Id = produto.Id;
            Descricao = produto.Descricao;
            Unidade = produto.Unidade;
            Valor = produto.Valor;
            ValorUnitario = produto.ValorUnitario;
            Foto = Converter(produto.Foto);
        }

        public ProdutoViewModel(ProdutoPedido produto)
        {
            if (produto is null)
                throw new ArgumentNullException(nameof(produto));

            Id = produto.ProdutoId;
            Descricao = produto.Descricao;
            Unidade = produto.Unidade;
            Valor = produto.Valor;
            ValorUnitario = produto.ValorUnitario;
            Quantidade = produto.Quantidade;
        }

        private ImageSource Converter(byte[] foto)
        {
            return ImageSource.FromStream(() => new MemoryStream(foto));
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string Unidade { get; private set; }
        public decimal Valor { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public ImageSource Foto { get; private set; }

        public string ValorPorUnidade => Valor.ToString("c2") + " por " + Unidade;

        public string QuantidadeCompradaComUnidadeEValor => Quantidade + " " + Unidade + " de " + Valor.ToString("c2");

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
