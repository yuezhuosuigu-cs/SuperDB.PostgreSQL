using Npgsql;

using SuperDB.Config;

using System.Data;

namespace SuperDB.PostgreSQL
{
    public class PostgreSQLFactory : DBFactory
    {
        private IDbConnection _Connection;

        public static PostgreSQLFactory Create()
        {
            return new PostgreSQLFactory();
        }

        public override IDbConnection Connection
        {
            get
            {
                if (_Connection == default)
                {
                    _Connection = new NpgsqlConnection(DBConfig.ConnectionString);
                }
                if (_Connection.State != ConnectionState.Open)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }
    }
}
