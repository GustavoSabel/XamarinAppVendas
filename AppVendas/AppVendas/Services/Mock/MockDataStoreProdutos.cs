using AppVendas.Models;
using AppVendas.Services.Base;
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

            Add("Beterraba em conserva 12x500g Danimar", "CX12", 5.83m, 70);
            Add("Brocolis em conserva 15x300g Danimar B", "CX15", 5.33m, 80);
            Add("Cenoura em conserva 15x300g Danimar", "CX15", 5.33m, 80);
            Add("Mini salsichas em conserva 12x180g DANIMAR", "CX12", 6.46m, 77.50m);
            Add("Ovos de codorna em conserva 15x300 DANIMAR", "CX15", 6.87m, 103);

            return produtos;

            void Add(string descricao, string unidade, decimal valorUnitario, decimal valor)
            {
                produtos.Add(new Produto
                {
                    Id = ++id,
                    Descricao = descricao,
                    Unidade = unidade,
                    Valor = valor,
                    ValorUnitario = valorUnitario
                });
            }
        }

        public async Task<IEnumerable<Produto>> ObterPorCliente(int clienteId)
        {
            var produtos = await GetManyAsync();
            if (clienteId == 1)
                return produtos.ToList();
            if (clienteId == 2)
                return produtos.Skip(3);
            else
                return new List<Produto>();
        }
    }
}