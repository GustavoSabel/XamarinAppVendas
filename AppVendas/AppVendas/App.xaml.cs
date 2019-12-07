using AppVendas.Repository;
using AppVendas.Services;
using AppVendas.Services.Mock.Helpers;
using AppVendas.Views;
using System.Globalization;
using Xamarin.Forms;

namespace AppVendas
{
    public partial class App : Application
    {
        public const string PROPERTIES_USUARIO_ID = "UsuarioId";
        public const string PROPERTIES_USUARIO_NOME = "UsuarioNome";
        public const string EVENT_LAUNCH_LOGIN_PAGE = "EVENT_LAUNCH_LOGIN_PAGE";
        public const string EVENT_LAUNCH_MAIN_PAGE = "EVENT_LAUNCH_MAIN_PAGE";

        public App()
        {
            InitializeComponent();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            if (!ConexaoApp.BaseExiste())
            {
                CriadorBaseInicial.CriarDadosFake().Wait();
            }

            DependencyService.Register<UsuarioRepository>();
            DependencyService.Register<ClienteRepository>();
            DependencyService.Register<PedidoRepository>();
            DependencyService.Register<ProdutoRepository>();

            DependencyService.Register<MockDataStoreUsuario>();
            DependencyService.Register<MockDataStoreClientes>();
            DependencyService.Register<MockDataStoreProdutos>();
            DependencyService.Register<MockDataStorePedido>();

            MessagingCenter.Subscribe<object>(this, EVENT_LAUNCH_LOGIN_PAGE, SetLoginPageAsRootPage);
            MessagingCenter.Subscribe<object>(this, EVENT_LAUNCH_MAIN_PAGE, SetMainPageAsRootPage);

            //MainPage = new AppShell();
            if (Application.Current.Properties.ContainsKey(App.PROPERTIES_USUARIO_ID))
                MainPage = new AppShell();
            else
                MainPage = new LoginPage();
        }

        private void SetLoginPageAsRootPage(object sender)
        {
            MainPage = new LoginPage();
        }

        private void SetMainPageAsRootPage(object sender)
        {
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
