using AppVendas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public class MockDataStoreProdutos : DataStore<Produto>, IDataStoreProdutos
    {
        static int id = 0;
        protected override IEnumerable<Produto> Load()
        {
            var produtos = new List<Produto>();

            Add("Produto A");
            Add("Produto B");
            Add("Produto C");
            Add("Produto D");

            return produtos;

            void Add(string descricao)
            {
                produtos.Add(new Produto
                {
                    Id = ++id,
                    Descricao = descricao,
                    Unidade = "PC",
                    Valor = 1m,
                    ValorUnitario = 1m
                });
            }
        }

        public async Task<IEnumerable<Produto>> ObterPorCliente(int clienteId)
        {
            var produtos = await GetManyAsync();
            if (clienteId == 1)
                return produtos.Take(3);
            if (clienteId == 2)
                return produtos.Skip(3);
            else
                return new List<Produto>();
        }
    }
}