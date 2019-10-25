using AppVendas.Models;
using AppVendas.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public class MockDataStorePedido : DataStore<Pedido>, IDataStorePedido
    {
        protected override IEnumerable<Pedido> Load()
        {
            var vendas = new List<Pedido>
            {
                new Pedido
                {
                    Id = 1,
                    ClienteId = 1,
                    ValorTotal = 300,
                    Data = new DateTime(2019,10,1,15,00,00),
                    Produtos = new List<ProdutoPedido>
                    {
                        new ProdutoPedido
                        {
                            ProdutoId = 1,
                            Descricao = "Beterraba em conserva 12x500g Danimar",
                            Unidade = "CX12",
                            Valor = 70m,
                            ValorUnitario = 5.83m,
                            Quantidade = 10,
                            ValorTotal = 500
                        },
                        new ProdutoPedido
                        {
                            ProdutoId = 2,
                            Descricao = "Ovos de codorna em conserva 15x300 DANIMAR",
                            Unidade = "CX12",
                            Valor = 20m,
                            ValorUnitario = 5.83m,
                            Quantidade = 20,
                            ValorTotal = 200
                        },
                        new ProdutoPedido
                        {
                            ProdutoId = 3,
                            Descricao = "Beterraba em conserva 12x500g Danimar",
                            Unidade = "CX15",
                            Valor = 10m,
                            ValorUnitario = 5.83m,
                            Quantidade = 05,
                            ValorTotal = 700
                        }
                    }
                },
                new Pedido
                {
                    Id = 2,
                    ClienteId = 1,
                    ValorTotal = 1000,
                    Data = new DateTime(2019,5,15,17,30,00),
                    Produtos = new List<ProdutoPedido>
                    {
                        new ProdutoPedido
                        {
                            ProdutoId = 1,
                            Descricao = "Ovos de codorna em conserva 15x300 DANIMAR",
                            Unidade = "CX15",
                            Valor = 77.50m,
                            ValorUnitario = 5.83m,
                            Quantidade = 40,
                            ValorTotal = 1000
                        }
                    }
                },
                new Pedido
                {
                    Id = 3,
                    ClienteId = 1,
                    ValorTotal = 800.75m,
                    Data = new DateTime(2018,12,1,08,00,00),
                    Produtos = new List<ProdutoPedido>
                    {
                        new ProdutoPedido
                        {
                            ProdutoId = 1,
                            Descricao = "Beterraba em conserva 12x500g Danimar",
                            Unidade = "CX12",
                            Valor = 70m,
                            ValorUnitario = 5.83m,
                            Quantidade = 50,
                            ValorTotal = 700
                        }
                    }
                }
            };
            return vendas;
        }

        public Task<IEnumerable<Pedido>> ObterPorCliente(int clienteId)
        {
            var ultimosPedios = Entidades.Where(x => x.ClienteId == clienteId).OrderByDescending(x => x.Data).ToList();
            return Task.FromResult((IEnumerable<Pedido>)ultimosPedios);
        }
    }
}