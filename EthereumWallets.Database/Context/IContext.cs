using System.Data;

namespace EthereumWallets.Database.Context
{
    public interface IContext
    {
        IDbConnection CreateConnection();
    }
}
