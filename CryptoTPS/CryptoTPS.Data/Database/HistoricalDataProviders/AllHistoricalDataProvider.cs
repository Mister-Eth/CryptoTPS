using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public class AllHistoricalDataProvider : HistoricalDataProviderBase<TpsDataAll>
    {
        public AllHistoricalDataProvider(CryptoTPSContext context) : base("All", context, x => x.TpsDataAlls, TimeSpan.MaxValue)
        {

        }
    }
}
