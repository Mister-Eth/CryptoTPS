using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices.Scan.Implementations
{
    [Provider("Fantom")]
    public class FTMScanBlockInfoProvider : ScanBlockInfoProviderBase
    {
        public FTMScanBlockInfoProvider(IConfiguration configuration) : base(configuration, "FTMScan")
        {
        }
    }
}
