using EthereumWallets.Domain.Models;
using EthereumWallets.Domain.Pagination;
using EthereumWallets.Pagination;

namespace EthereumWallets.Services
{
    public interface IEthereumWalletService
    {
        Task<PaginatedResult<Wallet>> GetPaginatedWallets(PaginationParameters paginationParameters);
    }
}
