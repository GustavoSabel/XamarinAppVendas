using AppVendas.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AppVendas.ViewModels.NovoPedidoViewModel;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrinhoPage : ContentPage
    {
        private readonly CarrinhoViewModel viewModel;

        public CarrinhoPage(IEnumerable<ProdutoViewModel> produtos)
        {
            InitializeComponent();

            BindingContext = viewModel = new CarrinhoViewModel(produtos);
            Title = viewModel.Title;
        }
    }
}