
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

        public NovoPedidoPage(Cliente cliente)
        {
            InitializeComponent();
            Title = "Venda para " + cliente.NomeFantasia;
            BindingContext = viewModel = new NovoPedidoViewModel(DependencyService.Get<IDataStoreProdutos>(), cliente.Id);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!viewModel.Loaded)
            {
                viewModel.LoadCommand.Execute(null);
            }
        }
    }
}