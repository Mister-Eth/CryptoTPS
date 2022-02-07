
using Microsoft.Extensions.Configuration;

namespace CryptoTPS.Services.BlockchainServices
{
    [Provider("Habitat")]
    public class HabitatBlockInfoProvider : JSONRPCBlockInfoProviderBase
    {
        public HabitatBlockInfoProvider(IConfiguration configuration) : base(configuration, "Habitat")
        {
        }
    }
}
