using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public class OneYearHistoricalDataProvider : HistoricalDataProviderBase<TpsDataYear>
    {
        public OneYearHistoricalDataProvider(CryptoTPSContext context) : base("OneYear", context, x => x.TpsDataYears, TimeSpan.FromDays(365))
        {

        }
    }
}
