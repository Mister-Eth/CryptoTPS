using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices.BlockTime
{
    public interface IBlockTimeProvider
    {
        public double GetBlockTime();
    }
}
