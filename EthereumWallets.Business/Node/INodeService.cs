namespace EthereumWallets.Business.Node
{
    public interface INodeService
    {
        Task<decimal> GetAccountBalance(string account);
    }
}
