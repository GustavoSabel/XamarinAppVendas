using AppVendas.Models;
using AppVendas.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppVendas.Services
{
    public class MockDataStorePedido : DataStore<Pedido>, IDataStorePedido
    {
        protected override IEnumerable<Pedido> Load()
        {
            var produtoServico = DependencyService.Get<IDataStoreProdutos>();
            var produto1 = produtoServico.GetAsync(1).Result;
            var produto2 = produtoServico.GetAsync(2).Result;
            var produto3 = produtoServico.GetAsync(3).Result;

            var vendas = new List<Pedido>
            {
                new Pedido
                {
                    Id = 1,
                    ClienteId = 1,
                    Data = new DateTime(2019,10,1,15,00,00),
                    Produtos = new List<ProdutoPedido>
                    { 
                        Criar(produto1, 10),
                        Criar(produto2, 15),
                        Criar(produto3, 17),
                    }
                },
                new Pedido
                {
                    Id = 2,
                    ClienteId = 1,
                    Data = new DateTime(2019,5,15,17,30,00),
                    Produtos = new List<ProdutoPedido>
                    {
                        Criar(produto1, 20),
                    }
                },
                new Pedido
                {
                    Id = 3,
                    ClienteId = 1,
                    Data = new DateTime(2018,12,1,08,00,00),
                    Produtos = new List<ProdutoPedido>
                    {
                         Criar(produto3, 50),
                    }
                }
            };

            foreach (var venda in vendas)
            {
                venda.ValorTotal = venda.Produtos.Sum(x => x.ValorTotal);
            }

            return vendas;
        }

        private static ProdutoPedido Criar(Produto produto, decimal qtd)
        {
            return new ProdutoPedido
            {
                ProdutoId = produto.Id,
                Descricao = produto.Descricao,
                Unidade = produto.Unidade,
                Valor = produto.Valor,
                ValorUnitario = produto.ValorUnitario,
                Quantidade = qtd,
                ValorTotal = produto.Valor * qtd,
                Foto = produto.Foto
            };
        }

        public Task<IEnumerable<Pedido>> ObterPorCliente(int clienteId)
        {
            var ultimosPedios = Entidades.Where(x => x.ClienteId == clienteId).OrderByDescending(x => x.Data).ToList();
            return Task.FromResult((IEnumerable<Pedido>)ultimosPedios);
        }
    }
}