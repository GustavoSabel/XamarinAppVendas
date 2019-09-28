using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public class AboutViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(() => Launcher.OpenAsync(new Uri("https://xamarin.com/platform")));
        }

        public string Title { get; }

        public ICommand OpenWebCommand { get; }
    }
}