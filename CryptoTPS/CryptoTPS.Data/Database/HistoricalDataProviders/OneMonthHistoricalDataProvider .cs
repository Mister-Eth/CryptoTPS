using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public class OneMonthHistoricalDataProvider : HistoricalDataProviderBase<TpsDataMonth>
    {
        public OneMonthHistoricalDataProvider(CryptoTPSContext context) : base("OneMonth", context, x => x.TpsDataMonths, TimeSpan.FromDays(30))
        {

        }
    }
}
