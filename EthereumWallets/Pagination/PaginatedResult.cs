using EthereumWallets.Domain.Pagination;

namespace EthereumWallets.Pagination
{
    public class PaginatedResult<T> where T : class
    {
        public List<T> Wallets { get; set; }

        public PaginationModel Metadata { get; set; }
    }
}
