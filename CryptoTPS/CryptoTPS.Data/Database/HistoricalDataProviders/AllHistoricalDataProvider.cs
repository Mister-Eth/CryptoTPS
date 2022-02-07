using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public class AllHistoricalDataProvider : HistoricalDataProviderBase<TpsandGasDataAll>
    {
        public AllHistoricalDataProvider(CryptoTPSContext context) : base("All", context, x => x.TpsandGasDataAlls, TimeSpan.MaxValue)
        {

        }
    }
}
