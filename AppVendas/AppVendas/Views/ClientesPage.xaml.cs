using AppVendas.Models;
using AppVendas.Services.Base;
using AppVendas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientesPage : ContentPage
    {
        private readonly ClientesViewModel viewModel;

        public ClientesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ClientesViewModel(DependencyService.Get<IDataStore<Cliente>>());
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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FiltroCommand.Execute(e.NewTextValue);
        }
    }
}
