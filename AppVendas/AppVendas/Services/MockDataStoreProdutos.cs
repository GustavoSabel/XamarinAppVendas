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

            Add("Produto A", 1);
            Add("Produto B", 2);
            Add("Produto C", 3);
            Add("Produto D", 4);

            return produtos;

            void Add(string descricao, decimal valorUnitario)
            {
                produtos.Add(new Produto
                {
                    Id = ++id,
                    Descricao = descricao,
                    Unidade = "PC",
                    Valor = valorUnitario,
                    ValorUnitario = valorUnitario
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