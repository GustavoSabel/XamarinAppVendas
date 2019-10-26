using AppVendas.Models;
using AppVendas.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePage : ContentPage
    {
        private readonly ClienteViewModel viewModel;
        private readonly Cliente _cliente;

        public ClientePage(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            BindingContext = viewModel = new ClienteViewModel(cliente);
            Title = cliente.NomeFantasia;
        }

        private async void BtnNovoPedido_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NovoPedidoPage(_cliente)).ConfigureAwait(false);
        }

        private async void BtnPedidosAnteriores_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PedidosPorClientePage(_cliente)).ConfigureAwait(false);
        }
    }
}