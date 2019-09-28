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
            BindingContext = viewModel = new ClientesViewModel();
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
