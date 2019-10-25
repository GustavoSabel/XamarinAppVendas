
using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoPedidoPage : ContentPage
    {
        private readonly NovoPedidoViewModel viewModel;
        private readonly Cliente _cliente;

        public NovoPedidoPage(Cliente cliente)
        {
            InitializeComponent();
            Title = "Venda para " + cliente.NomeFantasia;

            var dataStore = DependencyService.Get<IDataStoreProdutos>();
            BindingContext = viewModel = new NovoPedidoViewModel(dataStore);
            _cliente = cliente;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (!viewModel.Loaded)
            {
                await viewModel.Carregar(_cliente.Id).ConfigureAwait(false);
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FiltroCommand.Execute(e.NewTextValue);
        }

        private void BtnCarrinho_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CarrinhoPage(_cliente, viewModel.Produtos));
        }
    }
}