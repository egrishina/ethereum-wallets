using EthereumWallets.Business.Node;
using Microsoft.Extensions.DependencyInjection;

namespace EthereumWallets.Node
{
    public static class Composer
    {
        public static IServiceCollection AddNodeService(this IServiceCollection services)
        {
            services.AddSingleton<INodeService, NodeService>();
            return services;
        }
    }
}
