
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
            MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_LOGIN_PAGE);
        });

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
            Navigation.PushModalAsync(new LoginPage());
        }

        private void MenuItem_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}