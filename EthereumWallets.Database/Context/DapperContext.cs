using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace EthereumWallets.Database.Context
{
    public class DapperContext : IContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnectionString")!;
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}
