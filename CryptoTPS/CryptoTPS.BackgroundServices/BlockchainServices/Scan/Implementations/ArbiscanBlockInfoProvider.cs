using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices.Scan.Implementations
{
    [Provider("Polygon")]
    public class PolygonScanBlockInfoProvider : ScanBlockInfoProviderBase
    {
        public PolygonScanBlockInfoProvider(IConfiguration configuration) : base(configuration, "Polygonscan")
        {
        }
    }
}
