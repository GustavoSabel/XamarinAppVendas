using AppVendas.Models;
using AppVendas.Models.Base;
using Polly;
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
        private readonly Lazy<SQLiteAsyncConnection> _connection;

        private static readonly string NomeBase =
            Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "SqliteDatabase.db3");

        private ConexaoApp()
        {
            _connection = new Lazy<SQLiteAsyncConnection>(() =>
            {
                var con = new SQLiteAsyncConnection(NomeBase, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
                con.CreateTableAsync<Usuario>().Wait();
                con.CreateTableAsync<UsuarioCliente>().Wait();
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

        public AsyncTableQuery<T> Table<T>() where T : new()
        {
            return _connection.Value.Table<T>();
        }

        internal Task DeleteAsync(object obj)
        {
            return AttemptAndRetry(() => _connection.Value.DeleteAsync(obj));
        }

        internal Task InsertAsync<T>(T obj) where T : IEntidade
        {
            return AttemptAndRetry(() => _connection.Value.InsertAsync(obj));
        }

        internal Task<List<T>> QueryAsync<T>(string query, params object[] args) where T : new()
        {
            return AttemptAndRetry(() => _connection.Value.QueryAsync<T>(query, args));
        }

        internal Task<T> FindWithQueryAsync<T>(string query, params object[] args) where T : new()
        {
            return AttemptAndRetry(() => _connection.Value.FindWithQueryAsync<T>(query, args));
        }

        internal Task<int> InsertAllAsync(IEnumerable objects)
        {
            return AttemptAndRetry(() => _connection.Value.InsertAllAsync(objects));
        }

        internal Task<int> UpdateAsync(object obj)
        {
            return AttemptAndRetry(() => _connection.Value.UpdateAsync(obj));
        }

        internal Task<int> ExecuteAsync(string query, params object[] args)
        {
            return AttemptAndRetry(() => _connection.Value.ExecuteAsync(query, args));
        }

        protected static Task<T> AttemptAndRetry<T>(Func<Task<T>> action, int numRetries = 3)
        {
            return Policy.Handle<SQLiteException>().WaitAndRetryAsync(numRetries, PollyRetryAttempt).ExecuteAsync(action);
            static TimeSpan PollyRetryAttempt(int attemptNumber) => TimeSpan.FromSeconds(Math.Pow(2, attemptNumber));
        }
    }
}
