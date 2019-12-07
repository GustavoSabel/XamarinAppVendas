using System;
using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels;
using Xamarin.Essentials;
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
            var usuarioId = (int)Application.Current.Properties[App.PROPERTIES_USUARIO_ID];
            BindingContext = viewModel = new ClientesViewModel(DependencyService.Get<IDataStoreClientes>(), usuarioId);
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
            await Navigation.PushAsync(new ClientePage(cliente)).ConfigureAwait(false);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FiltroCommand.Execute(e.NewTextValue);
        }
    }
}
