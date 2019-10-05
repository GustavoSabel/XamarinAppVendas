using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientesPage : ContentPage
    {
        private readonly ClientesViewModel viewModel;

        public ClientesPage(IDataStore<Cliente> dataStoreCliente)
        {
            InitializeComponent();
            BindingContext = viewModel = new ClientesViewModel(dataStoreCliente);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!viewModel.Loaded)
            {
                viewModel.LoadCommand.Execute(null);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var tappedEventArgs = (TappedEventArgs)e;
            var cliente = (Cliente)tappedEventArgs.Parameter;
            Navigation.PushAsync(new NovoPedidoPage(cliente));
        }
    }
}
