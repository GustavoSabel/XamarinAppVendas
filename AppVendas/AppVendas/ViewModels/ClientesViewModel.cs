using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private readonly IDataStore<Cliente> _dataStoreClientes;

        public ObservableCollection<Cliente> Clientes { get; set; }
        public ICommand LoadCommand { get; }
        public bool Loaded { get; private set; }

        public ClientesViewModel(IDataStore<Cliente> dataStoreClientes)
        {
            _dataStoreClientes = dataStoreClientes;
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
                var items = await _dataStoreClientes.GetManyAsync();
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
