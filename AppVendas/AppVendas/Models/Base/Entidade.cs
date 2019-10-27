using SQLite;

namespace AppVendas.Models.Base
{
    public abstract class Entidade : IEntidade
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
