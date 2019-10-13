using AppVendas.Services;
using AppVendas.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidoPage : ContentPage
    {
        private readonly PedidoViewModel viewModel;
        private readonly int _pedidoId;

        public PedidoPage(int pedidoId)
        {
            InitializeComponent();
            _pedidoId = pedidoId;
            BindingContext = viewModel = new PedidoViewModel(DependencyService.Get<IDataStorePedido>(), DependencyService.Get<IDataStoreClientes>());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (!viewModel.Loaded)
                await viewModel.Carregar(_pedidoId);
        }
    }
}