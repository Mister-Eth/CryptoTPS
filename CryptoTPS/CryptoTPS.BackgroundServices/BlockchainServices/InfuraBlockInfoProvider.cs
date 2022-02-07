using CryptoTPS.Data.Extensions;
using CryptoTPS.Services.BlockchainServices.BlockTime;
using CryptoTPS.Services.BlockchainServices.Models.JSONRPC;
using CryptoTPS.Services.Infrastructure.Serialization;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices
{
    [Provider("Ethereum")]
    public class InfuraBlockInfoProvider : JSONRPCBlockInfoProviderBase
    {
        public InfuraBlockInfoProvider(IConfiguration configuration, EthereumBlockTimeProvider ethereumBlockTimeProvider) : base(configuration, "Infura")
        {
            BlockTimeSeconds = ethereumBlockTimeProvider.GetBlockTime();
        }
    }
}
