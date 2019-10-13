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

        public ClientesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ClientesViewModel(DependencyService.Get<IDataStoreClientes>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!viewModel.Loaded)
            {
                viewModel.LoadCommand.Execute(null);
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var tappedEventArgs = (TappedEventArgs)e;
            var cliente = (Cliente)tappedEventArgs.Parameter;
            await Navigation.PushAsync(new ClientePage(cliente));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FiltroCommand.Execute(e.NewTextValue);
        }
    }
}
