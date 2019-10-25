using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidosPorClientePage : ContentPage
    {
        private readonly PedidosPorClienteViewModel viewModel;
        private readonly Cliente _cliente;

        public PedidosPorClientePage(Cliente cliente)
        {
            InitializeComponent();
            BindingContext = viewModel = new PedidosPorClienteViewModel(DependencyService.Get<IDataStorePedido>());
            _cliente = cliente;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (!viewModel.Loaded)
                await viewModel.Carregar(_cliente).ConfigureAwait(false);
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var tappedEventArgs = (TappedEventArgs)e;
            var pedido = (Pedido)tappedEventArgs.Parameter;
            await Navigation.PushAsync(new PedidoPage(pedido.Id)).ConfigureAwait(false);
        }
    }
}