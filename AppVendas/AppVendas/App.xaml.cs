using AppVendas.Repository;
using AppVendas.Services;
using AppVendas.Services.Mock.Helpers;
using AppVendas.Views;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppVendas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            if (!ConexaoApp.BaseExiste())
            {
                CriadorBaseInicial.Criar().Wait();
            }

            DependencyService.Register<ClienteRepository>();
            DependencyService.Register<PedidoRepository>();
            DependencyService.Register<ProdutoRepository>();

            DependencyService.Register<MockDataStoreClientes>();
            DependencyService.Register<MockDataStoreProdutos>();
            DependencyService.Register<MockDataStorePedido>();

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
