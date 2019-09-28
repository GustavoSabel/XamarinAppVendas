using AppVendas.Models;
using System;
using System.Collections.Generic;

namespace AppVendas.Services
{
    public class MockDataStoreClientes : DataStore<Cliente>
    {
        static int id = 0;

        protected override IEnumerable<Cliente> Load()
        {
            var clientes = new List<Cliente>();

            Add("Danimar LTDA", "Danimar", new DateTime(2019, 09, 15), "Gaspar", "SC");
            Add("Masala", "Masala", new DateTime(2019, 02, 07), "Itajaí", "SC");
            Add("Nuanoak", "Nuanoak", null, "Telêmaco Borba", "PR");
            Add("Zincoci", "Zincoci", null, "Gaspar", "SC");
            Add("Adankundîr", "Adankundîr", new DateTime(2019, 05, 18), "Blumenau", "SC");
            Add("Padaria Do João", "Padaria do João", null, "Gaspar", "SC");
            Add("Julio Tiago da Silvao", null, null, "São Paulo", "SP");
            Add("Pedro de Alcântara Francisco Antônio João Carlos Xavier", "Pedro de Alcântara Francisco", null, "Jijoca de Jericoacoara", "CE");

            return clientes;

            void Add(string razaoSocial, string nomeFantasia, DateTime? dataUltimoPedido, string cidade, string estadoSigla)
            {
                if (string.IsNullOrWhiteSpace(nomeFantasia))
                    nomeFantasia = null;

                clientes.Add(new Cliente
                {
                    Id = ++id,
                    RazaoSocial = razaoSocial,
                    NomeFantasia = nomeFantasia ?? razaoSocial,
                    DataUltimoPedido = dataUltimoPedido,
                    Cidade = cidade,
                    EstadoSigla = estadoSigla,
                });
            }
        }
    }
}