using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public class OneHourHistoricalDataProvider : HistoricalDataProviderBase<TpsDataHour>
    {
        public OneHourHistoricalDataProvider(CryptoTPSContext context) : base("OneHour", context, x => x.TpsDataHours, TimeSpan.FromHours(1))
        {

        }
    }
}
