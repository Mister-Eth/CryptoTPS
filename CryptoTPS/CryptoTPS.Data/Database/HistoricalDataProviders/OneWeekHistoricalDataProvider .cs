using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public class OneWeekHistoricalDataProvider : HistoricalDataProviderBase<TpsDataWeek>
    {
        public OneWeekHistoricalDataProvider(CryptoTPSContext context) : base("OneWeek", context, x => x.TpsDataWeeks, TimeSpan.FromDays(7))
        {

        }
    }
}
