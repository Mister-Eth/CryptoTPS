using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices.BlockInfoProviderImplementations
{
    [Provider("Ethereum")]
    public class EthereumBlockInfoProvider : IBlockInfoProvider
    {
        public double BlockTimeSeconds { get; set; }

        public Task<BlockInfo> GetBlockInfoAsync(int blockNumber)
        {
            throw new NotImplementedException();
        }

        public Task<BlockInfo> GetBlockInfoAsync(DateTime time)
        {
            throw new NotImplementedException();
        }

        public Task<BlockInfo> GetLatestBlockInfoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
