using EthereumWallets.Domain.Models;

namespace EthereumWallets.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<Wallet> Sort(this IEnumerable<Wallet> wallets, string sortOrder)
        {
            if (sortOrder == "desc")
            {
                return wallets.OrderByDescending(e => e.Balance);
            }
            else
            {
                return wallets.OrderBy(e => e.Balance);
            }
        }
    }
}
