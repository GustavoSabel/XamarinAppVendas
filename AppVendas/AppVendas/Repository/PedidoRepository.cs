using AppVendas.Models;
using AppVendas.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppVendas.Repository
{
    public class PedidoRepository : RepositoryBase<Pedido>
    {
        public Task<List<Pedido>> ObterPorCliente(int clienteId)
        {
            return Database.Conecao.QueryAsync<Pedido>($"SELECT * FROM Pedido WHERE ClienteId = ?", clienteId);
        }

        public override async Task<Pedido> ObterAsync(int id)
        {
            var pedido = await base.ObterAsync(id).ConfigureAwait(false);
            pedido.Produtos = await Database.Conecao.QueryAsync<ProdutoPedido>("SELECT * FROM ProdutoPedido WHERE PedidoId = ?", pedido.Id).ConfigureAwait(false);
            return pedido;
        }

        public override async Task SalvarAsync(Pedido pedido)
        {
            if (pedido is null)
                throw new System.ArgumentNullException(nameof(pedido));

            if (pedido.Id != 0)
            {
                await Database.Conecao.UpdateAsync(pedido).ConfigureAwait(false);
                await Database.Conecao.ExecuteAsync("DELETE FROM ProdutoPedido WHERE PedidoId = ?", pedido.Id).ConfigureAwait(false);
            }
            else
            {
                var id = await Database.Conecao.InsertAsync(pedido).ConfigureAwait(false);
                pedido.Id = id;
            }

            foreach (var produto in pedido.Produtos)
            {
                produto.PedidoId = pedido.Id;
            }

            await Database.Conecao.InsertAllAsync(pedido.Produtos).ConfigureAwait(false);
        }
    }
}
