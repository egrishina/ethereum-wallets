using Dapper;
using EthereumWallets.Business.Repository;
using EthereumWallets.Database.Context;
using EthereumWallets.Domain.Models;
using EthereumWallets.Domain.Pagination;

namespace EthereumWallets.Database
{
    public class WalletRepository : IWalletRepository
    {
        private readonly IContext _context;
        private int? _totalCount;

        public WalletRepository(IContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Wallet>> GetPaginatedAddresses(PaginationParameters paginationParameters)
        {
            var addresses = await GetAddresses(paginationParameters);

            if (!_totalCount.HasValue)
            {
                _totalCount = await GetCount();
            }

            var count = _totalCount.Value;
            var pagedList = PagedList<Wallet>.ToPagedList(
                addresses,
                count,
                paginationParameters.PageNumber,
                paginationParameters.PageSize);

            return pagedList;
        }

        public async Task<List<Wallet>> GetAddresses(PaginationParameters paginationParameters)
        {
            using var db = _context.CreateConnection();
            var parameters = new
            {
                Offset = (paginationParameters.PageNumber - 1) * paginationParameters.PageSize,
                Limit = paginationParameters.PageSize
            };

            var query = @"
                SELECT *
                FROM ""Wallets""
                ORDER BY ""Id""
                LIMIT @Limit
                OFFSET @Offset";

            var addresses = (await db.QueryAsync<AddressDao>(query, parameters)).ToList();
            var wallets = addresses.Select(ToDomainObject).ToList();
            return wallets;
        }

        public async Task<int> GetCount()
        {
            using var db = _context.CreateConnection();
            var query = @"
                SELECT COUNT(*)
                FROM ""Wallets""";

            var count = (await db.QueryAsync<int>(query)).First();
            return count;
        }

        private static Wallet ToDomainObject(AddressDao dao)
        {
            var wallet = new Wallet()
            {
                Id = dao.Id,
                Address = dao.Address
            };

            return wallet;
        }
    }
}
