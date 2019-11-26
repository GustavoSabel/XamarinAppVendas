using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //await Navigation.PopModalAsync().ConfigureAwait(false);
            MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_MAIN_PAGE);
        }
    }
}