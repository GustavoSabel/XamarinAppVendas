using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace AppVendas.ViewModels.Base
{
    public class BaseViewModel : ExtendedBindableObject, INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        private bool temInternet;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public bool TemInternet
        {
            get { return temInternet; }
            set
            {
                SetProperty(ref temInternet, value);
                RaisePropertyChanged(() => NaoTemInternet);
            }
        }

        public bool NaoTemInternet
        {
            get { return !temInternet; }
        }

        protected bool SetProperty<TProperty>(ref TProperty backingStore, TProperty value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<TProperty>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public BaseViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            TemInternet = Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            TemInternet = e.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
