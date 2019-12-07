
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public ICommand LogoffCommand => new Command(() =>
        {
            Application.Current.Properties.Remove(App.PROPERTIES_USUARIO_ID);
            Application.Current.Properties.Remove(App.PROPERTIES_USUARIO_NOME);
            Application.Current.SavePropertiesAsync();
            MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_LOGIN_PAGE);
        });

        public string NomeUsuario { get; set; }

        public AppShell()
        {
            InitializeComponent();

            NomeUsuario = (string)Application.Current.Properties[App.PROPERTIES_USUARIO_NOME];

            BindingContext = this;
        }

        private void MenuItem_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}