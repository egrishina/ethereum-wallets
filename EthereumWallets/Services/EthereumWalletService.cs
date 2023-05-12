using EthereumWallets.Business.Node;
using EthereumWallets.Business.Repository;
using EthereumWallets.Domain.Models;
using EthereumWallets.Domain.Pagination;
using EthereumWallets.Extensions;
using EthereumWallets.Pagination;

namespace EthereumWallets.Services
{
    public class EthereumWalletService : IEthereumWalletService
    {
        private readonly IWalletRepository _repository;
        private readonly INodeService _nodeService;

        public EthereumWalletService(IWalletRepository repository, INodeService nodeService)
        {
            _repository = repository;
            _nodeService = nodeService;
        }

        public async Task<PaginatedResult<Wallet>> GetPaginatedWallets(PaginationParameters paginationParameters)
        {
            var addresses = await _repository.GetPaginatedAddresses(paginationParameters);

            var wallets = new List<Wallet>();
            foreach (var a in addresses)
            {
                var wallet = new Wallet()
                {
                    Id = a.Id,
                    Address = a.Address,
                    Balance = await GetAccountBalance(a.Address)
                };

                wallets.Add(wallet);
            }

            var paginatedResult = new PaginatedResult<Wallet>
            {
                Wallets = wallets.Sort(paginationParameters.OrderBy).ToList(),
                Metadata = addresses.Metadata
            };

            return paginatedResult;
        }

        private async Task<decimal> GetAccountBalance(string? address)
        {
            if (address is null)
            {
                return 0;
            }

            var balance = await _nodeService.GetAccountBalance(address);
            return balance;
        }
    }
}
