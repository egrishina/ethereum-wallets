using EthereumWallets.Business.Node;
using Nethereum.Web3;

namespace EthereumWallets.Node
{
    public class NodeService : INodeService
    {
        private readonly string _testnetUrl = "https://mainnet.infura.io/v3/921c5fc7f415477eaf6803024f2ffcd0";
        private readonly Web3 _web3;

        public NodeService()
        {
            _web3 = new Web3(_testnetUrl);
        }

        public async Task<decimal> GetAccountBalance(string account)
        {
            var balance = await _web3.Eth.GetBalance.SendRequestAsync(account);
            var etherAmount = Web3.Convert.FromWei(balance.Value);
            return etherAmount;
        }
    }
}
