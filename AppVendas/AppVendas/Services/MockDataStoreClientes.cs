using AppVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public class MockDataStoreClientes : IDataStore<Cliente>
    {
        private static int id = 0;
        readonly List<Cliente> clientes = new List<Cliente>();

        public MockDataStoreClientes()
        {
            Add("Danimar LTDA", "Danimar", new DateTime(2019, 09, 15), "Gaspar", "SC");
            Add("Masala", "Masala", new DateTime(2019, 02, 07), "Itajaí", "SC");
            Add("Nuanoak", "Nuanoak", null, "Telêmaco Borba", "PR");
            Add("Zincoci", "Zincoci", null, "Gaspar", "SC");
            Add("Adankundîr", "Adankundîr", new DateTime(2019, 05, 18), "Blumenau", "SC");
            Add("Padaria Do João", "Padaria do João", null, "Gaspar", "SC");
            Add("Julio Tiago da Silvao", "", null, "São Paulo", "SP");
        }

        private void Add(string RazaoSocial, string NomeFantasia, DateTime? DataUltimoPedido, string cidade, string estadoSigla)
        {
            clientes.Add(new Cliente
            {
                Id = (++id).ToString(),
                RazaoSocial = RazaoSocial,
                NomeFantasia = NomeFantasia,
                DataUltimoPedido = DataUltimoPedido,
                Cidade = cidade,
                EstadoSigla = estadoSigla,
            });
        }

        public async Task<bool> AddAsync(Cliente cliente)
        {
            clientes.Add(cliente);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            var oldItem = clientes.Where(x => x.Id == cliente.Id).FirstOrDefault();
            clientes.Remove(oldItem);
            clientes.Add(cliente);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = clientes.Where(x => x.Id == id).FirstOrDefault();
            clientes.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Cliente> GetAsync(string id)
        {
            return await Task.FromResult(clientes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Cliente>> GetManyAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(clientes);
        }
    }
}