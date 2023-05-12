using EthereumWallets.Domain.Models;
using EthereumWallets.Domain.Pagination;

namespace EthereumWallets.Business.Repository
{
    public interface IWalletRepository
    {
        Task<PagedList<Wallet>> GetPaginatedAddresses(PaginationParameters paginationParameters);
        Task<List<Wallet>> GetAddresses(PaginationParameters paginationParameters);
        Task<int> GetCount();
    }
}
