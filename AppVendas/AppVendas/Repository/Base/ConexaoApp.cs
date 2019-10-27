using AppVendas.Models;
using SQLite;
using System;
using System.IO;

namespace AppVendas.Services
{
    public class ConexaoApp
    {
        public SQLiteAsyncConnection Conecao { get; }

        private ConexaoApp(string dbPath)
        {
            Conecao = new SQLiteAsyncConnection(dbPath);
            Conecao.CreateTableAsync<Cliente>().Wait();
            Conecao.CreateTableAsync<Produto>().Wait();
            Conecao.CreateTableAsync<ProdutoPedido>().Wait();
            Conecao.CreateTableAsync<Pedido>().Wait();
        }


        private static ConexaoApp _instancia;

        private static readonly string NomeBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");

        public static ConexaoApp Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ConexaoApp(NomeBase);
                }
                return _instancia;
            }
        }

        public static bool BaseExiste()
        {
            return File.Exists(NomeBase);
        }
    }
}
