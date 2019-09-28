using AppVendas.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public class ClientesViewModel : BaseViewModel<Cliente>
    {
        public ObservableCollection<Cliente> Clientes { get; set; }
        public Command LoadCommand { get; }
        public bool Loaded { get; private set; }

        public ClientesViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();
            Title = "Clientes";
            LoadCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Clientes.Clear();
                var items = await DataStore.GetManyAsync();
                foreach (var item in items)
                {
                    Clientes.Add(item);
                }
                Loaded = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
