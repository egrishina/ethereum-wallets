using EthereumWallets.Business.Repository;
using EthereumWallets.Database.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EthereumWallets.Database
{
    public static class Composer
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IContext, DapperContext>();
            services.AddSingleton<IWalletRepository, WalletRepository>();
            return services;
        }
    }
}