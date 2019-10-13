using AppVendas.Models;
using AppVendas.ViewModels.Base;
using System;

namespace AppVendas.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        private readonly Cliente _cliente;

        public string RazaoSocial => _cliente.RazaoSocial;
        public string NomeFantasia => _cliente.NomeFantasia;
        public string Cidade => _cliente.Cidade;
        public string EstadoSigla => _cliente.EstadoSigla;
        public string CidadeEstado => _cliente.CidadeEstado;
        public DateTime? DataUltimoPedido => _cliente.DataUltimoPedido;

        public ClienteViewModel(Cliente cliente)
        {
            Title = "Cliente";
            _cliente = cliente;
        }
    }
}
