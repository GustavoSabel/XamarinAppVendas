﻿using AppVendas.Models;
using AppVendas.Services;
using AppVendas.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppVendas.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private readonly IDataStoreClientes _dataStoreClientes;
        private readonly int _usuarioId;
        private IReadOnlyList<Cliente> _todosClientes;
        private IReadOnlyList<Cliente> clientes;

        public IReadOnlyList<Cliente> Clientes
        {
            get => clientes;
            set
            {
                clientes = value; 
                OnPropertyChanged();
            }
        }
        public ICommand LoadCommand { get; }

        public bool Loaded { get; private set; }

        public Command<string> FiltroCommand => new Command<string>((fitro) =>
        {
            if (string.IsNullOrEmpty(fitro))
                Clientes = _todosClientes.ToList();
            Clientes = _todosClientes.Where(x => x.RazaoSocial.Contains(fitro, StringComparison.InvariantCultureIgnoreCase) || x.NomeFantasia.Contains(fitro, StringComparison.InvariantCultureIgnoreCase)).ToList();
        });

        public ClientesViewModel(IDataStoreClientes dataStoreClientes, int usuarioId)
        {
            _dataStoreClientes = dataStoreClientes;
            _usuarioId = usuarioId;
            Title = "Clientes";
            LoadCommand = new Command(async () => await ExecuteLoadItemsCommand().ConfigureAwait(false));
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await _dataStoreClientes.ObterPorUsuario(_usuarioId).ConfigureAwait(false);
                _todosClientes = ConverterEmViewModel(items);
                Clientes = _todosClientes.ToList();

                Loaded = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private static List<Cliente> ConverterEmViewModel(IEnumerable<Cliente> items)
        {
            var clientesVM = new List<Cliente>();
            foreach (var item in items)
            {
                clientesVM.Add(item);
            }

            return clientesVM;
        }
    }
}
