using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrinhoPage : ContentPage
    {
        private readonly CarrinhoViewModel viewModel;
        private readonly Cliente _cliente;

        public CarrinhoPage(Cliente cliente, IEnumerable<ProdutoViewModel> produtos)
        {
            InitializeComponent();

            _cliente = cliente;
            BindingContext = viewModel = new CarrinhoViewModel(produtos);
            Title = viewModel.Title;
        }

        private async void BtnFinalizar_Clicked(object sender, EventArgs e)
        {
            var pedidoStore = DependencyService.Get<IDataStorePedido>();

            var pedido = new Pedido
            {
                ClienteId = _cliente.Id,
                Data = DateTime.Now,
                ValorTotal = viewModel.ValorTotal,
                Produtos = viewModel.ProdutosComQuantidade.Select(x => new ProdutoPedido
                {
                    Descricao = x.Descricao,
                    ProdutoId = x.Id,
                    Quantidade = x.Quantidade,
                    Unidade = x.Unidade,
                    Valor = x.Valor,
                    ValorTotal = x.ValorTotal,
                    ValorUnitario = x.ValorUnitario
                }).ToList()
            };

            await pedidoStore.AddAsync(pedido).ConfigureAwait(false);

            await DisplayAlert("Sucesso", "Pedido criado com sucesso!", "OK").ConfigureAwait(true);

            for (var counter = 1; counter < 2; counter++)
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}