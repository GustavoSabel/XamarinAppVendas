using AppVendas.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void EsqueciMinhaSenha_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Não implementado", "Essa funcionalidade ainda não foi implementada", "OK :(").ConfigureAwait(false);
        }

        private void Entrar_Clicked(object sender, EventArgs e)
        {
            var dataStore = DependencyService.Get<IDataStoreUsuarios>();

            var usuarioLogado = dataStore.ValidarUsuarioSenha(txtEmail.Text, txtSenha.Text).Result;
            if (usuarioLogado != null)
            {
                Application.Current.Properties.Add(App.PROPERTIES_USUARIO_ID, usuarioLogado.Id);
                Application.Current.Properties.Add(App.PROPERTIES_USUARIO_NOME, usuarioLogado.Nome);
                Application.Current.SavePropertiesAsync();
                MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_MAIN_PAGE);
            }
            else
            {
                DisplayAlert("Autenticação", "Usuário e/ou senha inválido", "OK :(");
            }
        }
    }
}