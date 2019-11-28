using AppVendas.Models;
using AppVendas.Models.Base;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppVendas.Services
{
    public class ConexaoApp
    {
        private readonly Lazy<SQLiteAsyncConnection> _conecao;

        private static readonly string NomeBase =
            Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "SqliteDatabase5.db3");

        private ConexaoApp()
        {
            _conecao = new Lazy<SQLiteAsyncConnection>(() =>
            {
                var con = new SQLiteAsyncConnection(NomeBase, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
                con.CreateTableAsync<Cliente>().Wait();
                con.CreateTableAsync<Produto>().Wait();
                con.CreateTableAsync<ProdutoPedido>().Wait();
                con.CreateTableAsync<Pedido>().Wait();
                return con;
            });
        }

        public readonly static ConexaoApp Instancia = new ConexaoApp();

        public static bool BaseExiste()
        {
            return File.Exists(NomeBase);
        }

        internal Task DeleteAsync(object obj) 
        {
            return _conecao.Value.DeleteAsync(obj);
        }

        public AsyncTableQuery<T> Table<T>() where T : new()
        {
            return _conecao.Value.Table<T>();
        }

        internal async Task InsertAsync<T>(T obj) where T : IEntidade
        {
            await _conecao.Value.InsertAsync(obj).ConfigureAwait(false);
        }

        internal Task<List<T>> QueryAsync<T>(string query, params object[] args) where T : new()
        {
            return _conecao.Value.QueryAsync<T>(query, args);
        }

        internal Task<int> InsertAllAsync(IEnumerable objects)
        {
            return _conecao.Value.InsertAllAsync(objects);
        }

        internal Task<int> UpdateAsync(object obj)
        {
            return _conecao.Value.UpdateAsync(obj);
        }

        internal Task<int> ExecuteAsync(string query, params object[] args)
        {
            return _conecao.Value.ExecuteAsync(query, args);
        }
    }
}
